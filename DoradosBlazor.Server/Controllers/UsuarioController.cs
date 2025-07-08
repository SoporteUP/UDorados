using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using DoradosBlazor.Server.Models;

using DoradosBlazor.Shared;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Newtonsoft.Json;
using System.Security.Claims;
namespace DoradosBlazorCrud.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DbcrudBlazorContext _dbContext;

        public UsuarioController(DbcrudBlazorContext dbCntext)
        {

            _dbContext = dbCntext;
        }



        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<UsuarioDTO>>();
            var listaUsuarioDTO = new List<UsuarioDTO>();

            try
            {
                foreach (var item in await _dbContext.Usuarios.Include(d => d.IdRolesNavigation).ToListAsync())
                {
                    listaUsuarioDTO.Add(new UsuarioDTO
                    {
                        UsuarioID = item.UsuarioID,
                        IdRol = item.IdRol,
                        Nombre = item.Nombre,
                        Correo = item.Correo,
                        Password = item.Password,
                        FechaReg = item.FechaReg,

                        Roles = new RolesDTO
                        {
                            IdRol = item.IdRolesNavigation.IdRol,
                            NombreRol = item.IdRolesNavigation.NombreRol

                        }
                    });

                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaUsuarioDTO;

            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

            }
            return Ok(responseApi);
        }

        [HttpGet]
        [Route("SiExisteCorreo/{Correo}")]
        public async Task<ActionResult> SiExisteCorreo(string Correo)
        {
            //ExisteCorreo existeCorreo = new ExisteCorreo();
            CorreoDTO correoDTO = new CorreoDTO();

            var Result = new List<Correo>();

            Result = _dbContext.Correos.FromSql($"ST_S_SiExisteCorreo {Correo}").ToList();

            if (Result.Count > 0)
            {
                correoDTO.ExisteCorreo = int.Parse(Result[0].ExisteCorreo.ToString());
                correoDTO.Email = Result[0].Email.ToString();
            }
            else
            {
                correoDTO.ExisteCorreo = 0;
                correoDTO.Email = Correo;
            }

            return StatusCode(StatusCodes.Status200OK, correoDTO);
        }

        [HttpGet]
        [Route("SiExisteMatricula/{MatriculaID}")]
        public async Task<ActionResult> SiExisteMatricula(string MatriculaID)
        {
            MatriculaDTO matriculaDTO = new MatriculaDTO();
            //ExisteCorreo existeCorreo = new ExisteCorreo();

            var Result = new List<SiExisteMatricula>();

            Result = _dbContext.siExisteMatricula.FromSql($"ST_S_SiExisteMatricula {MatriculaID}").ToList();


            if (Result.Count > 0)
            {
                matriculaDTO.MatriculaID = Result[0].MatriculaID.ToString();
                matriculaDTO.Nombre = Result[0].Nombre.ToString();
                matriculaDTO.RolID = int.Parse(Result[0].RolID.ToString());

            }
            else
            {
                matriculaDTO.MatriculaID = "";
                matriculaDTO.Nombre = "";
                matriculaDTO.RolID = 1000;
            }


            return StatusCode(StatusCodes.Status200OK, matriculaDTO);
        }

        [HttpGet]
        [Route("ST_S_CiclosApp/{TipoConsulta}/{MatriculaID}")]
        public async Task<ActionResult> ST_S_CiclosApp(int TipoConsulta, string MatriculaID)
        {
            CiclosDTO ciclosDTO = new CiclosDTO();
            //ExisteCorreo existeCorreo = new ExisteCorreo();
            var listaCiclosDTO = new List<CiclosDTO>();

            var Result = new List<Ciclos>();

            Result = _dbContext.ciclos.FromSql($"ST_S_CiclosApp {TipoConsulta}, {MatriculaID}").ToList();


            if (Result.Count > 0)
            {
                foreach (var item in Result)
                {
                    listaCiclosDTO.Add(new CiclosDTO
                    {
                        CicloID = item.CicloID,
                        Carrera = item.Carrera,
                        fechaInsc = item.fechaInsc,
                        TipoCiclo = item.TipoCiclo,
                    });

                }


            }



            return Ok(listaCiclosDTO);
        }


        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<UsuarioDTO>();
            var UsuarioDTO = new UsuarioDTO();

            try
            {
                var dbEmpleado = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.UsuarioID == id);

                if (dbEmpleado != null)
                {
                    UsuarioDTO.UsuarioID = dbEmpleado.UsuarioID;
                    UsuarioDTO.Nombre = dbEmpleado.Nombre;
                    UsuarioDTO.IdRol = dbEmpleado.IdRol;
                    UsuarioDTO.Correo = dbEmpleado.Correo;
                    UsuarioDTO.Password = dbEmpleado.Password;
                    UsuarioDTO.FechaReg = dbEmpleado.FechaReg;


                    responseApi.EsCorrecto = true;
                    responseApi.Valor = UsuarioDTO;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No encontrado";
                }

            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }


        //ST_S_PREINSCRIP Get
        [HttpGet]
        [Route("ST_S_PREINSCRIP/{iTipoConsulta}/{sUsuario}/{iMatriculaID}/{sNombre}")]
        public async Task<IActionResult> ST_S_PREINSCRIP(int iTipoConsulta, string sUsuario, int iMatriculaID, string sNombre)
        {
            var responseApi = new ResponseAPI<List<ST_S_PREINSCRIPDTO>>();
            var listaPREINSCRIPDTO = new List<ST_S_PREINSCRIPDTO>();

            var Result = _dbContext.sT_S_PREINSCRIP.FromSql($"ST_S_PREINSCRIP {iTipoConsulta},{sUsuario},{iMatriculaID},{sNombre}").ToList();

            try
            {
                foreach (var item in Result)
                {
                    listaPREINSCRIPDTO.Add(new ST_S_PREINSCRIPDTO
                    {
                        MatriculaID = item.MatriculaID,
                        Nombre = item.Nombre,
                        Apellido_paterno = item.Apellido_paterno,
                        Apellido_materno = item.Apellido_materno,
                        Edad = item.Edad,
                        Direccion = item.Direccion,
                        Colonia = item.Colonia,
                        Ciudad = item.Ciudad,
                        CodigoPostal = item.CodigoPostal,
                        Telefono = item.Telefono,
                        Email = item.Email,
                        EscuelaProcedencia = item.EscuelaProcedencia,
                        LugardeNacimiento = item.LugardeNacimiento,
                        Nacionalidad = item.Nacionalidad,
                        Sexo = item.Sexo,
                        FechaNacimiento = item.FechaNacimiento,
                        EstadoCivil = item.EstadoCivil,
                        Ocupacion = item.Ocupacion,
                        Sector = item.Sector,
                        ServicioMedico = item.ServicioMedico,
                        Curp = item.Curp,
                        CarreraID = item.CarreraID,
                        Carrera = item.Carrera,
                        fechaInsc = item.fechaInsc,
                        ID = item.ID,
                        Atendio = item.Atendio,
                        CicloID = item.CicloID,
                        MedioEntero = item.MedioEntero,
                        NombreTutor = item.NombreTutor,
                        APTutor = item.APTutor,
                        AMTutor = item.AMTutor,
                        OcupacionTutor = item.OcupacionTutor,
                        ParentescoTutor = item.ParentescoTutor,
                        TelTutor = item.TelTutor,
                        CorreoTutor = item.CorreoTutor,
                        DireccionTutor = item.DireccionTutor,
                        CasoEmergencia = item.CasoEmergencia,
                        Parentesco = item.Parentesco,
                        TelEmergencia = item.TelEmergencia,
                        CorreoEmergencia = item.CorreoEmergencia,


                    });

                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaPREINSCRIPDTO;

            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

            }
            return Ok(responseApi);
        }


        //ST_S_PREINSCRIPCOUNT Get
        [HttpGet]
        [Route("ST_S_PREINSCRIPCOUNT/{iTipoConsulta}/{sUsuario}/{iMatriculaID}/{sNombre}")]
        public async Task<IActionResult> ST_S_PREINSCRIPCOUNT(int iTipoConsulta, string sUsuario, int iMatriculaID, string sNombre)
        {
            var responseApi = new ResponseAPI<List<ST_S_PREINSCRIPCOUNTDTO>>();
            var listaPREINSCRIPDTO = new List<ST_S_PREINSCRIPCOUNTDTO>();

            var Result = _dbContext.sT_S_PREINSCRIPCOUNT.FromSql($"ST_S_PREINSCRIPCOUNT {iTipoConsulta},{sUsuario},{iMatriculaID},{sNombre}").ToList();

            try
            {
                foreach (var item in Result)
                {
                    listaPREINSCRIPDTO.Add(new ST_S_PREINSCRIPCOUNTDTO
                    {
                        TotalPreins = item.TotalPreins, 

                    });

                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaPREINSCRIPDTO;

            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

            }
            return Ok(responseApi);
        }

        //ST_S_CARRERAS Get
        [HttpGet]
        [Route("ST_S_CARRERAS/{iTipoConsulta}/{sCarrera}")]
        public async Task<IActionResult> ST_S_CARRERAS(int iTipoConsulta, string sCarrera)
        {
            var responseApi = new ResponseAPI<List<ST_S_CARRERASDTO>>();
            var listaCARRERASDTO = new List<ST_S_CARRERASDTO>();

            var Result = _dbContext.sT_S_CARRERAS.FromSql($"ST_S_CARRERAS {iTipoConsulta},{sCarrera}").ToList();

            try
            {
                foreach (var item in Result)
                {
                    listaCARRERASDTO.Add(new ST_S_CARRERASDTO
                    {
                        CarreraID = item.CarreraID,
                        IncorporacionID = item.IncorporacionID,
                        NivelEducativoID = item.NivelEducativoID,
                        Carrera = item.Carrera,
                        Nivel = item.Nivel,
                        AñodelPlan = item.AñodelPlan,
                        Vigente = item.Vigente,
                        Inscripcion = item.Inscripcion,
                        Mensualidad = item.Mensualidad,
                        TipoCiclo = item.TipoCiclo,


                    });

                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaCARRERASDTO;

            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

            }
            return Ok(responseApi);
        }


        //ST_S_PREINSC_INCOMP Get
        [HttpGet]
        [Route("ST_S_PREINSC_INCOMP/{iTipoConsulta}/{sNombre}")]
        public async Task<IActionResult> ST_S_PREINSC_INCOMP(int iTipoConsulta, string sNombre)
        {
            var responseApi = new ResponseAPI<List<ST_S_PREINSC_INCOMPDTO>>();
            var listaPREINSC_INCOMP = new List<ST_S_PREINSC_INCOMPDTO>();

            var Result = _dbContext.sT_S_PREINSC_INCOMP.FromSql($"ST_S_PREINSC_INCOMP {iTipoConsulta},{sNombre}").ToList();

            try
            {
                foreach (var item in Result)
                {
                    listaPREINSC_INCOMP.Add(new ST_S_PREINSC_INCOMPDTO
                    {
                        MatriculaID = item.MatriculaID,
                        Nombre = item.Nombre,
                        Apellido_paterno = item.Apellido_paterno,
                        Apellido_materno = item.Apellido_materno,                       
                        Edad = item.Edad,
                        Direccion = item.Direccion,
                        Colonia = item.Colonia,
                        Ciudad = item.Ciudad,
                        CodigoPostal = item.CodigoPostal,
                        Telefono = item.Telefono,
                        Email = item.Email,
                        EscuelaProcedencia = item.EscuelaProcedencia,
                        LugardeNacimiento = item.LugardeNacimiento,
                        Nacionalidad = item.Nacionalidad,
                        Sexo = item.Sexo,
                        FechaNacimiento = item.FechaNacimiento,
                        EstadoCivil = item.EstadoCivil,
                        Ocupacion = item.Ocupacion,
                        Sector = item.Sector,
                        ServicioMedico = item.ServicioMedico,
                        Curp = item.Curp,
                        CarreraID = item.CarreraID,
                        Carrera = item.Carrera,
                        fechaInsc = item.fechaInsc,
                        ID = item.ID,
                        Atendio = item.Atendio,
                        CicloID = item.CicloID,
                        MedioEntero = item.MedioEntero,
                        NombreTutor = item.NombreTutor,
                        APTutor = item.APTutor,
                        AMTutor = item.AMTutor,
                        OcupacionTutor = item.OcupacionTutor,
                        ParentescoTutor = item.ParentescoTutor,
                        TelTutor = item.TelTutor,
                        CorreoTutor = item.CorreoTutor,
                        DireccionTutor = item.DireccionTutor,
                        CasoEmergencia = item.CasoEmergencia,
                        Parentesco = item.Parentesco,
                        TelEmergencia = item.TelEmergencia,
                        CorreoEmergencia = item.CorreoEmergencia,


                    });

                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaPREINSC_INCOMP;

            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

            }
            return Ok(responseApi);
        }


        //ST_S_DatosPDF Get
        [HttpGet]
        [Route("ST_S_DatosPDF/{iTipoConsulta}/{iID}")]
        public async Task<IActionResult> ST_S_DatosPDF(int iTipoConsulta, string iID)
        {
            var responseApi = new ResponseAPI<List<ST_S_DatosPDFDTO>>();
            var listaDatosPDF = new List<ST_S_DatosPDFDTO>();

            var Result = _dbContext.sT_S_DatosPDF.FromSql($"ST_S_DatosPDF {iTipoConsulta},{iID}").ToList();

            try
            {
                foreach (var item in Result)
                {
                    listaDatosPDF.Add(new ST_S_DatosPDFDTO
                    {
                        MatriculaID = item.MatriculaID,
                        Nombre = item.Nombre,
                        fechadealta = item.fechadealta,
                        Edad = item.Edad,
                        Direccion = item.Direccion,
                        Telefono = item.Telefono,
                        Colonia = item.Colonia,
                        Ciudad = item.Ciudad,
                        CodigoPostal = item.CodigoPostal,                        
                        Email = item.Email,
                        EscuelaProcedencia = item.EscuelaProcedencia,
                        LugardeNacimiento = item.LugardeNacimiento,
                        Nacionalidad = item.Nacionalidad,
                        Sexo = item.Sexo,
                        FechaNacimiento = item.FechaNacimiento,
                        EstadoCivil = item.EstadoCivil,
                        Ocupacion = item.Ocupacion,
                        Sector = item.Sector,
                        ServicioMedico = item.ServicioMedico,
                        Curp = item.Curp,
                        Carrera = item.Carrera,
                        fechaInsc = item.fechaInsc,
                        Atendio = item.Atendio,
                        CicloID = item.CicloID,
                        MedioEntero = item.MedioEntero,
                        NombreTutor = item.NombreTutor,
                        OcupacionTutor = item.OcupacionTutor,
                        TelefonoTutor = item.TelefonoTutor,
                        CorreoTutor = item.CorreoTutor,
                        DireccionTutor = item.DireccionTutor,
                        CasoEmergencia = item.CasoEmergencia,
                        Parentesco = item.Parentesco,
                        CorreoEmergencia = item.CorreoEmergencia,
                        TelEmergencia = item.TelEmergencia,
                        FirmaA = item.FirmaA,
                        FirmaT = item.FirmaT,
                        


                    });

                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaDatosPDF;

            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

            }
            return Ok(responseApi);
        }


        //ST_S_CorreosMisCuentas Get
        [HttpGet]
        [Route("ST_S_CorreosMisCuentas/{iTipoConsulta}/{sCorreo}")]
        public async Task<IActionResult> ST_S_CorreosMisCuentas(int iTipoConsulta, string sCorreo)
        {
            var responseApi = new ResponseAPI<List<ST_S_CorreosMisCuentasDTO>>();
            var listaCorreosMisCuentas = new List<ST_S_CorreosMisCuentasDTO>();

            var Result = _dbContext.sT_S_CorreosMisCuentas.FromSql($"ST_S_CorreosMisCuentas {iTipoConsulta},{sCorreo}").ToList();

            try
            {
                foreach (var item in Result)
                {
                    listaCorreosMisCuentas.Add(new ST_S_CorreosMisCuentasDTO
                    {
                        Usuario = item.Usuario,
                        Contraseña = item.Contraseña,
                        Nombre = item.Nombre,
                        Asunto = item.Asunto,
                        Mensaje = item.Mensaje,
                        smtp = item.smtp,
                        Puerto = item.Puerto,
                        Predeterminado = item.Predeterminado,  

                    });

                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaCorreosMisCuentas;

            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

            }
            return Ok(responseApi);
        }


        //ST_S_ProspecFiltros Get
        [HttpGet]
        [Route("ST_S_ProspecFiltros/{cCampo}/{cBusqueda}/{cCampo2}/{cBusqueda2}")]
        public async Task<IActionResult> ST_S_ProspecFiltros(string cCampo, string cBusqueda, string cCampo2, string cBusqueda2)
        {
            var responseApi = new ResponseAPI<List<ST_S_ProspecFiltrosDTO>>();
            var listaProspecFiltros = new List<ST_S_ProspecFiltrosDTO>();

            var Result = _dbContext.sT_S_ProspecFiltros.FromSql($"ST_S_ProspecFiltros {cCampo},{cBusqueda},{cCampo2},{cBusqueda2}").ToList();

            try
            {
                foreach (var item in Result)
                {
                    listaProspecFiltros.Add(new ST_S_ProspecFiltrosDTO
                    {
                        ProspectoID = item.ProspectoID,
                        EjecutivoID = item.EjecutivoID,
                        Nombre = item.Nombre,
                        Telefono = item.Telefono,
                        Celular = item.Celular,
                        Correo = item.Correo,
                        Localidad = item.Localidad,
                        AreaInteres = item.AreaInteres,
                        EscuelaProcedencia = item.EscuelaProcedencia,
                        CicloEscolar = item.CicloEscolar,
                        Edad = item.Edad,
                        MedioseEntero = item.MedioseEntero,
                        QuienAtendio = item.QuienAtendio,
                        Estatus = item.Estatus,
                        Llamo = item.Llamo,
                        Ubicacion = item.Ubicacion,
                        Facebook = item.Facebook,
                        Niv_AcademicoInteres = item.Niv_AcademicoInteres,
                        Base = item.Base,
                        Turno = item.Turno,
                        Institu_Evento = item.Institu_Evento,

                    });

                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaProspecFiltros;

            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

            }
            return Ok(responseApi);
        }


        [HttpPost]
        [Route("ListaGposEmpaquetados")]
        public async Task<ActionResult> ListaGposEmpaquetados([FromBody] ST_S_GposEmpaquetadosVarDTO sT_S_GposEmpaquetadosVarDTO)
        {
            var responseApi = new ResponseAPI<List<ST_S_GposEmpaquetadosDTO>>();

            ST_S_GposEmpaquetadosDTO sT_S_GposEmpaquetadosDTO = new ST_S_GposEmpaquetadosDTO();

            var listaDTO = new List<ST_S_GposEmpaquetadosDTO>();

            var students = new List<ST_S_GposEmpaquetados>();

            students = _dbContext.sT_S_GposEmpaquetados.FromSql($"ST_S_GposEmpaquetados {sT_S_GposEmpaquetadosVarDTO.iTipoOperacion}, {sT_S_GposEmpaquetadosVarDTO.CarreraID},{sT_S_GposEmpaquetadosVarDTO.CicloID},{sT_S_GposEmpaquetadosVarDTO.GrupoID},{sT_S_GposEmpaquetadosVarDTO.ProfesorID},{sT_S_GposEmpaquetadosVarDTO.MateriaID}").ToList();

            foreach (var item in students)
            {
                listaDTO.Add(new ST_S_GposEmpaquetadosDTO
                {
                    FaltaCalif = item.FaltaCalif,                   
                });

            }

            responseApi.Valor = listaDTO;

            return Ok(responseApi);
        }

        [HttpPost]
        [Route("ListaGposEmpaquetadosListos")]
        public async Task<ActionResult> ListaGposEmpaquetadosListos([FromBody] ST_S_GposEmpaquetadosVarDTO sT_S_GposEmpaquetadosVarDTO)
        {
            var responseApi = new ResponseAPI<List<ST_S_GposEmpaquetadosListosDTO>>();

            ST_S_GposEmpaquetadosListosDTO sT_S_GposEmpaquetadosListosDTO = new ST_S_GposEmpaquetadosListosDTO();

            var listaDTO = new List<ST_S_GposEmpaquetadosListosDTO>();

            var students = new List<ST_S_GposEmpaquetadosListos>();

            students = _dbContext.sT_S_GposEmpaquetadosListos.FromSql($"ST_S_GposEmpaquetadosListos {sT_S_GposEmpaquetadosVarDTO.iTipoOperacion}, {sT_S_GposEmpaquetadosVarDTO.CarreraID},{sT_S_GposEmpaquetadosVarDTO.CicloID},{sT_S_GposEmpaquetadosVarDTO.GrupoID},{sT_S_GposEmpaquetadosVarDTO.ProfesorID},{sT_S_GposEmpaquetadosVarDTO.MateriaID}").ToList();

            foreach (var item in students)
            {
                listaDTO.Add(new ST_S_GposEmpaquetadosListosDTO
                {
                    Empaquetado = item.Empaquetado,
                });

            }

            responseApi.Valor = listaDTO;

            return Ok(responseApi);
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO login)
        {
            SesionDTO sesionDTO = new SesionDTO();

            var students = new List<Login>();

            students = _dbContext.Login.FromSql($"ST_S_LoginApp {login.Correo}, {login.Password}").ToList();

            sesionDTO.Nombre = students[0].Nombre.ToString();
            sesionDTO.Correo = students[0].Correo.ToString();
            sesionDTO.Rol = students[0].NombreRol.ToString();
            sesionDTO.MatriculaID = students[0].MatriculaID.ToString();


            return StatusCode(StatusCodes.Status200OK, sesionDTO);
        }

        [HttpPost]
        [Route("ListaCiclos")]
        public async Task<ActionResult> ListaCiclos([FromBody] CiclosVarDTO ciclosVar)
        {
            var responseApi = new ResponseAPI<List<CiclosDTO>>();

            CiclosDTO ciclosDTO = new CiclosDTO();

            var listaCiclosDTO = new List<CiclosDTO>();

            var students = new List<Ciclos>();

            students = _dbContext.ciclos.FromSql($"ST_S_CiclosApp {ciclosVar.TipoOperacion}, {ciclosVar.MatriculaID}").ToList();

                    foreach (var item in students)
                    {
                        listaCiclosDTO.Add(new CiclosDTO
                        {
                            CicloID = item.CicloID,
                            CarreraID = item.CarreraID,
                            Carrera = item.Carrera,
                            fechaInsc = item.fechaInsc,
                            TipoCiclo = item.TipoCiclo,
                        });

                    }

         
                responseApi.Valor = listaCiclosDTO;
                                
                            
           
            return Ok(responseApi);
        }


        [HttpPost]
        [Route("ListaCaliParc")]
        public async Task<ActionResult> ListaCaliParc([FromBody] CalifVarDTO califVar)
        {
            var responseApi = new ResponseAPI<List<CaliParcDTO>>();

            CaliParcDTO caliParcDTO = new CaliParcDTO();

            var listaCalifDTO = new List<CaliParcDTO>();

            var students = new List<CalificacionesPar>();

            students = _dbContext.calificacionesPar.FromSql($"ST_S_CaliParc_AlumnoApp {califVar.iTipoConsulta}, {califVar.sMatriculaID},{califVar.iCarreraID},{califVar.sCiclo}").ToList();

            if (students.Count > 0)
            {
                try
                {
                    foreach (var item in students)
                    {
                        listaCalifDTO.Add(new CaliParcDTO
                        {
                            MateriaID = item.MateriaID,
                            CarreraID = item.CarreraID,
                            Carrera = item.Carrera,
                            CicloID = item.CicloID,
                            GrupoID = item.GrupoID,
                            Materia = item.Materia,
                            MatriculaID = item.MatriculaID,
                            Alumno = item.Alumno,
                            Parcial1 = item.Parcial1,
                            F1 = item.F1,
                            Parcial2 = item.Parcial2,
                            F2 = item.F2,
                            Parcial3 = item.Parcial3,
                            F3 = item.F3,
                            PromediodeParciales = item.PromediodeParciales,
                            ExamenFinal = item.ExamenFinal,
                            CalificacionFinal = item.CalificacionFinal,
                            Observaciones = item.Observaciones,
                        });


                    }
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = listaCalifDTO;

                }
                catch (Exception ex)
                {

                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = ex.Message;

                }

            }
            return Ok(responseApi);
        }

        [HttpPost]
        [Route("ListaCaliMens")]
        public async Task<ActionResult> ListaCaliMens([FromBody] CalifVarDTO califVar)
        {
            var responseApi = new ResponseAPI<List<CaliMensDTO>>();

            CaliMensDTO caliMensDTO = new CaliMensDTO();

            var listaCalifDTO = new List<CaliMensDTO>();

            var students = new List<CalificacionesMens>();

            students = _dbContext.calificacionesMens.FromSql($"ST_S_CaliMens_AlumnoApp {califVar.iTipoConsulta}, {califVar.sMatriculaID},{califVar.iCarreraID},{califVar.sCiclo}").ToList();

            if (students.Count > 0)
            {
                try
                {
                    foreach (var item in students)
                    {
                        listaCalifDTO.Add(new CaliMensDTO
                        {
                            CarreraID = item.CarreraID,
                            Carrera = item.Carrera,
                            CicloID = item.CicloID,
                            GrupoID = item.GrupoID,
                            MateriaID = item.MateriaID,
                            Materia = item.Materia,
                            MatriculaID = item.MatriculaID,
                            Alumno = item.Alumno,
                            Septiembre = item.Septiembre,
                            F1 = item.F1,
                            Octubre = item.Octubre,
                            F2 = item.F2,
                            PromBim1 = item.PromBim1,
                            Noviembre = item.Noviembre,
                            F3 = item.F3,
                            Diciembre = item.Diciembre,
                            F4 = item.F4,
                            PromBim2 = item.PromBim2,
                            Enero = item.Enero,
                            F5 = item.F5,
                            Febrero = item.Febrero,
                            F6 = item.F6,
                            PromBim3 = item.PromBim3,
                            Marzo = item.Marzo,
                            F7 = item.F7,
                            Abril = item.Abril,
                            F8 = item.F8,
                            PromBim4 = item.PromBim4,
                            Mayo = item.Mayo,
                            F9 = item.F9,
                            Junio = item.Junio,
                            F10 = item.F10,
                            PromBim5 = item.PromBim5,
                            PromedioGeneral = item.PromedioGeneral,
                            Observaciones = item.Observaciones
                        });

                    }
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = listaCalifDTO;

                }
                catch (Exception ex)
                {

                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = ex.Message;

                }

            }
            return Ok(responseApi);
        }

        [HttpPost]
        [Route("ListaCaliTrim")]
        public async Task<ActionResult> ListaCaliTrim([FromBody] CalifVarDTO califVar)
        {
            var responseApi = new ResponseAPI<List<CaliTrimDTO>>();

            CaliTrimDTO caliTrimDTO = new CaliTrimDTO();

            var listaCalifDTO = new List<CaliTrimDTO>();

            var students = new List<CalificacionesTrim>();

            students = _dbContext.calificacionesTrim.FromSql($"ST_S_CaliTrim_AlumnoApp {califVar.iTipoConsulta}, {califVar.sMatriculaID},{califVar.iCarreraID},{califVar.sCiclo}").ToList();

            if (students.Count > 0)
            {
                try
                {
                    foreach (var item in students)
                    {
                        listaCalifDTO.Add(new CaliTrimDTO
                        {
                            CarreraID = item.CarreraID,
                            Carrera = item.Carrera,
                            CicloID = item.CicloID,
                            GrupoID = item.GrupoID,
                            MateriaID = item.MateriaID,
                            Materia = item.Materia,
                            MatriculaID = item.MatriculaID,
                            Alumno = item.Alumno,
                            Septiembre = item.Septiembre,
                            F1 = item.F1,
                            Octubre = item.Octubre,
                            F2 = item.F2,
                            Noviembre = item.Noviembre,
                            F3 = item.F3,
                            Prom1 = item.Prom1,
                            DicEne = item.DicEne,
                            F4 = item.F4,
                            Febrero = item.Febrero,
                            F6 = item.F6,
                            Marzo = item.Marzo,
                            F7 = item.F7,
                            Prom2 = item.Prom2,
                            Abril = item.Abril,
                            F8 = item.F8,
                            Mayo = item.Mayo,
                            F9 = item.F9,
                            Junio = item.Junio,
                            F10 = item.F10,
                            Prom3 = item.Prom3,
                            PromedioGeneral = item.PromedioGeneral
                        });

                    }
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = listaCalifDTO;

                }
                catch (Exception ex)
                {

                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = ex.Message;

                }

            }
            return Ok(responseApi);
        }

        [HttpPost]
        [Route("ListaAdeudosAlum")]
        public async Task<ActionResult> ListaAdeudosAlum([FromBody] AdeudosVarDTO adeudosVar)
        {
            var responseApi = new ResponseAPI<List<AdeudosAlumDTO>>();

            AdeudosAlumDTO adeudosAlumDTO = new AdeudosAlumDTO();

            var listaAdeudosAlumDTO = new List<AdeudosAlumDTO>();

            var students = new List<AdeudosAlum>();

            students = _dbContext.adeudosAlum.FromSql($"ST_S_Adedudos_RpteMod2App {adeudosVar.iTipoOperacion}, {adeudosVar.sMatricula},{adeudosVar.dFechaIni},{adeudosVar.dFechaFin}").ToList();
            
              
                    foreach (var item in students)
                    {
                        listaAdeudosAlumDTO.Add(new AdeudosAlumDTO
                        {
                            ColegiaturaTramiteID = item.ColegiaturaTramiteID,
                            CarreraID = item.CarreraID,
                            CicloID = item.CicloID,
                            GrupoID = item.GrupoID,
                            MatriculaID = item.MatriculaID,
                            Concepto = item.Concepto,
                            FechaApagar = item.FechaApagar,
                            FechaVencimiento = item.FechaVencimiento,
                            DiasMorosos = item.DiasMorosos,
                            Importe = item.Importe,
                            ImporteBecaDesc = item.ImporteBecaDesc,
                            ImporteRecargos = item.ImporteRecargos,
                            ImporteTotal = item.ImporteTotal,
                            Abono = item.Abono,
                            Saldo = item.Saldo,
                            Alumno = item.Alumno,
                            Carrera = item.Carrera,

                        });

                }

           
                //responseApi.EsCorrecto = true;
                responseApi.Valor = listaAdeudosAlumDTO;
           

           
            return Ok(responseApi);
        }


        [HttpPost]
        [Route("ListaConAdeudo")]
        public async Task<ActionResult> ListaConAdeudo([FromBody] AdeudosVarDTO adeudosVar)
        {
            var responseApi = new ResponseAPI<List<ConAdeudoDTO>>();

            ConAdeudoDTO conAdeudoDTO = new ConAdeudoDTO();

            var listaConAdeudoDTO = new List<ConAdeudoDTO>();

            var students = new List<ConAdeudo>();

            students = _dbContext.conAdeudo.FromSql($"ST_S_ConAdedudos {adeudosVar.iTipoOperacion}, {adeudosVar.sMatricula}").ToList();


            foreach (var item in students)
            {
                listaConAdeudoDTO.Add(new ConAdeudoDTO
                {
                    conAdeudo = item.conAdeudo
                   

                });

            }


            //responseApi.EsCorrecto = true;
            responseApi.Valor = listaConAdeudoDTO;



            return Ok(responseApi);
        }


        [HttpPost]
        [Route("TotalAdeudos")]
        public async Task<ActionResult> TotalAdeudos([FromBody] AdeudosVarDTO adeudosVar)
        {
            var responseApi = new ResponseAPI<List<TotalAdeudosDTO>>();

            TotalAdeudosDTO adeudosTotalDTO = new TotalAdeudosDTO();

            var listaAdeudosTotalDTO = new List<TotalAdeudosDTO>();

            var students = new List<TotalAdeudos>();

            students = _dbContext.adeudosTotal.FromSql($"ST_S_Adedudos_TotalApp {adeudosVar.iTipoOperacion}, {adeudosVar.sMatricula},{adeudosVar.dFechaIni},{adeudosVar.dFechaFin}").ToList();

            if (students.Count > 0)
            {
                try
                {
                    foreach (var item in students)
                    {
                        listaAdeudosTotalDTO.Add(new TotalAdeudosDTO
                        {
                            TotalNeto = item.TotalNeto,


                        });

                    }
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = listaAdeudosTotalDTO;

                }
                catch (Exception ex)
                {

                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = ex.Message;

                }

            }
            return Ok(responseApi);
        }

        [HttpPost]
        [Route("ListaMateriasProfesores")]
        public async Task<ActionResult> ListaMateriasProfesores([FromBody] MateriasProfesoresVar materiasProfesoresVar)
        {
            var responseApi = new ResponseAPI<List<MateriasProfesoresDTO>>();

            MateriasProfesoresDTO materiasProfesoresDTO = new MateriasProfesoresDTO();

            var listamateriasProfesoresDTO = new List<MateriasProfesoresDTO>();

            var materias = new List<MateriasProfesores>();

            materias = _dbContext.materiasprofesores.FromSql($"ST_S_MateriasProfesores {materiasProfesoresVar.iTipoConsulta}, {materiasProfesoresVar.sCorreo}").ToList();


            foreach (var item in materias)
            {
                listamateriasProfesoresDTO.Add(new MateriasProfesoresDTO
                {
                    MateriaID = item.MateriaID,
                    ProfesorID = item.ProfesorID,
                    Profesor = item.Profesor,
                    CarreraID = item.CarreraID,
                    Carrera = item.Carrera,
                    Materia = item.Materia,
                    CicloID = item.CicloID,
                    GrupoID = item.GrupoID,
                     

    });

            }


            //responseApi.EsCorrecto = true;
            responseApi.Valor = listamateriasProfesoresDTO;



            return Ok(responseApi);
        }

        [HttpPost]
        [Route("ListaGruposAlumApp")]
        public async Task<ActionResult> ListaGruposAlumApp([FromBody] GruposAlumAppVarDTO gruposAlumAppVar)
        {
            var responseApi = new ResponseAPI<List<GruposAlumAppDTO>>();

            GruposAlumAppDTO gruposAlumAppDTO = new GruposAlumAppDTO();

            var listaGruposAlumAppDTO = new List<GruposAlumAppDTO>();

            var Alumnos = new List<GruposAlumApp>();

            Alumnos = _dbContext.gruposAlumApp.FromSql($"ST_S_GruposAlumApp {gruposAlumAppVar.iTipoConsulta}, {gruposAlumAppVar.iCarreraID},{gruposAlumAppVar.sCicloID},{gruposAlumAppVar.sGrupoID}").ToList();


            foreach (var item in Alumnos)
            {
                listaGruposAlumAppDTO.Add(new GruposAlumAppDTO
                {
                    MatriculaID = item.MatriculaID,
                    Nombre = item.Nombre,
                    GrupoID = item.GrupoID,
                    CicloID = item.CicloID,                  


                });

            }


            //responseApi.EsCorrecto = true;
            responseApi.Valor = listaGruposAlumAppDTO;



            return Ok(responseApi);
        }

        [HttpPost]
        [Route("ListaCalificacionAlumApp")]
        public async Task<ActionResult> ListaCalificacionAlumApp([FromBody] CalificacionAlumAppVarDTO calificacionAlumAppVar)
        {
            var responseApi = new ResponseAPI<List<CalificacionAlumAppDTO>>();

            CalificacionAlumAppDTO calificacionAlumAppDTO = new CalificacionAlumAppDTO();

            var listaCalificacionAlumAppDTO = new List<CalificacionAlumAppDTO>();

            var Calificaciones = new List<CalificacionAlumApp>();

            Calificaciones = _dbContext.calificacionAlumApp.FromSql($"ST_S_CalificacionAlumApp {calificacionAlumAppVar.iTipoConsulta}, {calificacionAlumAppVar.sMatriculaID},{calificacionAlumAppVar.sGrupoID},{calificacionAlumAppVar.sCicloID},{calificacionAlumAppVar.Email},{calificacionAlumAppVar.MateriaID}").ToList();

            if (Calificaciones.Count > 0)
            {
                foreach (var item in Calificaciones)
                {
                    listaCalificacionAlumAppDTO.Add(new CalificacionAlumAppDTO
                    {
                        CalificacionID = item.CalificacionID,
                        MateriaID = item.MateriaID,
                        MatriculaID = item.MatriculaID,
                        Nombre = item.Nombre,
                        CicloID = item.CicloID,
                        GrupoID = item.GrupoID,
                        Materia = item.Materia,
                        Septiembre = item.Septiembre,
                        Octubre = item.Octubre,
                        PromBim1 = item.PromBim1,
                        Noviembre = item.Noviembre,
                        Diciembre = item.Diciembre,
                        PromBim2 = item.PromBim2,
                        Enero = item.Enero,
                        Febrero = item.Febrero,
                        PromBim3 = item.PromBim3,
                        Marzo = item.Marzo,
                        Abril = item.Abril,
                        PromBim4 = item.PromBim4,
                        Mayo = item.Mayo,
                        Junio = item.Junio,
                        PromBim5 = item.PromBim5,
                        PromedioGeneral = item.PromedioGeneral,
                        Observaciones = item.Observaciones

                    });

                }


                //responseApi.EsCorrecto = true;
                responseApi.Valor = listaCalificacionAlumAppDTO;
                
            }

            return Ok(responseApi);


        }

        [HttpPost]
        [Route("ListaCalificacionParcAlumApp")]
        public async Task<ActionResult> ListaCalificacionParcAlumApp([FromBody] CalificacionAlumAppVarDTO calificacionAlumAppVar)
        {
            var responseApi = new ResponseAPI<List<CalificacionParcAlumAppDTO>>();

            CalificacionParcAlumAppDTO calificacionParcAlumAppDTO = new CalificacionParcAlumAppDTO();

            var listaCalificacionParcAlumAppDTO = new List<CalificacionParcAlumAppDTO>();

            var Calificaciones = new List<CalificacionParcAlumApp>();

            Calificaciones = _dbContext.calificacionParcAlumApp.FromSql($"ST_S_CalificacionParcAlumApp {calificacionAlumAppVar.iTipoConsulta}, {calificacionAlumAppVar.sMatriculaID},{calificacionAlumAppVar.sGrupoID},{calificacionAlumAppVar.sCicloID},{calificacionAlumAppVar.Email},{calificacionAlumAppVar.MateriaID}").ToList();


            foreach (var item in Calificaciones)
            {
                listaCalificacionParcAlumAppDTO.Add(new CalificacionParcAlumAppDTO
                {
                    CalificacionID = item.CalificacionID,
                    MateriaID = item.MateriaID,
                    MatriculaID = item.MatriculaID,
                    Nombre = item.Nombre,
                    CicloID = item.CicloID,
                    GrupoID = item.GrupoID,
                    Materia = item.Materia,
                    Parcial1 = item.Parcial1,
                    Parcial2 = item.Parcial2,
                    Parcial3 = item.Parcial3,
                    PromediodeParciales = item.PromediodeParciales,
                    ExamenFinal = item.ExamenFinal,
                    CalificacionFinal = item.CalificacionFinal,
                    Observaciones = item.Observaciones,                 

                });

            }


            //responseApi.EsCorrecto = true;
            responseApi.Valor = listaCalificacionParcAlumAppDTO;



            return Ok(responseApi);
        }

        [HttpPost]
        [Route("ListaCalificacionMateriaApp")]
        public async Task<ActionResult> ListaCalificacionMateriaApp([FromBody] CalificacionMateriaAppVarDTO calificacionMateriaAppVar)
        {
            var responseApi = new ResponseAPI<List<CalificacionMateriaAppDTO>>();

            CalificacionMateriaAppDTO calificacionMateriaAppDTO = new CalificacionMateriaAppDTO();

            var listaCalificacionMateriaAppDTO = new List<CalificacionMateriaAppDTO>();

            var Calificacion = new List<CalificacionMateriaApp>();

            Calificacion = _dbContext.calificacionMateriaApp.FromSql($"ST_S_CalificacionMateriaApp {calificacionMateriaAppVar.iTipoConsulta}, {calificacionMateriaAppVar.sMatriculaID},{calificacionMateriaAppVar.sGrupoID},{calificacionMateriaAppVar.sCicloID},{calificacionMateriaAppVar.sMateriaID}").ToList();


            foreach (var item in Calificacion)
            {
                listaCalificacionMateriaAppDTO.Add(new CalificacionMateriaAppDTO
                {
                    MateriaID = item.MateriaID,
                    MatriculaID = item.MatriculaID,
                    Nombre = item.Nombre,
                    CicloID = item.CicloID,
                    GrupoID = item.GrupoID,
                    Materia = item.Materia,
                    Septiembre = item.Septiembre,
                    Octubre = item.Octubre,
                    PromBim1 = item.PromBim1,
                    Noviembre = item.Noviembre,
                    Diciembre = item.Diciembre,
                    PromBim2 = item.PromBim2,
                    Enero = item.Enero,
                    Febrero = item.Febrero,
                    PromBim3 = item.PromBim3,
                    Marzo = item.Marzo,
                    Abril = item.Abril,
                    PromBim4 = item.PromBim4,
                    Mayo = item.Mayo,
                    Junio = item.Junio,
                    PromBim5 = item.PromBim5,
                    PromedioGeneral = item.PromedioGeneral,
                    Observaciones = item.Observaciones

                });

            }


            //responseApi.EsCorrecto = true;
            responseApi.Valor = listaCalificacionMateriaAppDTO;



            return Ok(responseApi);
        }


        [HttpPost]
        [Route("IUD_Usuario")]
        public async Task<ActionResult> IUD_Usuario([FromBody] PasswordDTO password)
        {

            var Result1 = new List<Respuesta>();

            Result1 = _dbContext.respuesta.FromSql($"ST_IUD_Usuario {1},{password.UsuarioID},{password.Nombre},{password.RolID},{password.Correo},{password.Password},{password.MatriculaID}").ToList();

            return StatusCode(StatusCodes.Status200OK, Result1);
        }


        [HttpPost]
        [Route("ST_IUD_TUTORPREINSC")]
        public async Task<ActionResult> ST_IUD_TUTORPREINSC([FromBody] ST_IUD_TUTORPREINSCDTO tutorp)
        {

            var Result1 = new List<Respuesta>();

            Result1 = _dbContext.respuesta.FromSql($"ST_IUD_TUTORPREINSC {tutorp.iTipoOperacion},{tutorp.sMatriculaID},{tutorp.sNombre},{tutorp.sApellidoPaterno},{tutorp.sApellidoMaterno}, {tutorp.sParentesco}, {tutorp.sDireccion}, {tutorp.sColonia}, {tutorp.sCiudad},{tutorp.sEstado},{tutorp.sCodigoPostal} ,{tutorp.sTelefono}, {tutorp.sOcupacion}, {tutorp.sCorreo}, {tutorp.sFirma}, {tutorp.sUsuario}").ToList();

            return StatusCode(StatusCodes.Status200OK, Result1);

        }

        [HttpPost]
        [Route("ST_IUD_PREINSCRIP")]
        public async Task<ActionResult> ST_IUD_PREINSCRIP([FromBody] ST_IUD_PREINSCRIPDTO preIns)
        {

            var Result1 = new List<Respuesta>();

            Result1 = _dbContext.respuesta.FromSql($"ST_IUD_PREINSCRIP {preIns.iTipoOperacion},{preIns.sMatriculaID},{preIns.sCarreraID},{preIns.dFecha},{preIns.fBecaDesc}, {preIns.fColegiatura}, {preIns.sUsuario}, {preIns.sMedioEntero}, {preIns.fAbono},{preIns.sCicloID}").ToList();

            return StatusCode(StatusCodes.Status200OK, Result1);

        }

        [HttpPost]
        [Route("ST_IUD_Prospectos")]
        public async Task<ActionResult> ST_IUD_Prospectos([FromBody] ST_IUD_ProspectosDTO prospec)
        {

            var Result1 = new List<Respuesta>();

            Result1 = _dbContext.respuesta.FromSql($"ST_IUD_Prospectos {prospec.iTipoOperacion},{prospec.iProspectoID},{prospec.iEjecutivoID},{prospec.sNombre},{prospec.sTelefono}, {prospec.sCelular}, {prospec.sCorreo}, {prospec.sLocalidad}, {prospec.sAreaInteres},{prospec.sEscuelaProcedencia},{prospec.sCicloEscolar},{prospec.iEdad},{prospec.sMedioseEntero},{prospec.sQuienAtendio},{prospec.sEstatus},{prospec.sLlamo},{prospec.sUbicacion},{prospec.sFacebook},{prospec.sNiv_AcademicoInteres},{prospec.sBase},{prospec.sTurno},{prospec.sInstitu_Evento}").ToList();

            return StatusCode(StatusCodes.Status200OK, Result1);

        }

        [HttpPost]
        [Route("ST_IUE_ALUMNOSPREINSC")]
        public async Task<ActionResult> ST_IUE_ALUMNOSPREINSC([FromBody] ST_IUE_ALUMNOSPREINSCDTO alumnosp)
        {

            var Result1 = new List<Respuesta>();

            Result1 = _dbContext.respuesta.FromSql($"ST_IUE_ALUMNOSPREINSC {alumnosp.iTipoOperacion},{alumnosp.cMatriculaID},{alumnosp.cNombre},{alumnosp.cApellido_Paterno},{alumnosp.cApellido_Materno}, {alumnosp.FechaNacimiento}, {alumnosp.Sexo}, {alumnosp.Curp}, {alumnosp.RFC},{alumnosp.Direccion},{alumnosp.Colonia} ,{alumnosp.Ciudad}, {alumnosp.Estado}, {alumnosp.CodigoPostal}, {alumnosp.Telefono}, {alumnosp.Email}, {alumnosp.GradoMaximo}, {alumnosp.EscuelaProcedencia}, {alumnosp.sLugarNacimiento}, {alumnosp.sNacionalidad}, {alumnosp.cMatriculaNueva}, {alumnosp.fEdad}, {alumnosp.sCorreo}, {alumnosp.sOcupacion}, {alumnosp.sSector}, {alumnosp.sServicioMedico}, {alumnosp.sCasoEmergencia}, {alumnosp.sParentesco}, {alumnosp.sTelEmergencia}, {alumnosp.sCorreoEmergencia}, {alumnosp.sFirma}, {alumnosp.sUsuario}").ToList();

            return StatusCode(StatusCodes.Status200OK, Result1);

        }


        [HttpPost]
        [Route("U_CalificaMensualesApp")]
        public async Task<ActionResult> U_CalificaMensualesApp([FromBody] UCalifMenAppVarDTO uCalifMenAppVar)
        {

            var Result1 = new List<Respuesta>();

            Result1 = _dbContext.respuesta.FromSql($"ST_U_CalificaMensualesApp {uCalifMenAppVar.iTipoOperacion},{uCalifMenAppVar.CalificacionID},{uCalifMenAppVar.Sep},{uCalifMenAppVar.Oct},{uCalifMenAppVar.PromBim1},{uCalifMenAppVar.Nov},{uCalifMenAppVar.Dic},{uCalifMenAppVar.PromBim2},{uCalifMenAppVar.Ene},{uCalifMenAppVar.Feb},{uCalifMenAppVar.PromBim3},{uCalifMenAppVar.Mar},{uCalifMenAppVar.Abr},{uCalifMenAppVar.PromBim4},{uCalifMenAppVar.May},{uCalifMenAppVar.Jun},{uCalifMenAppVar.PromBim5},{uCalifMenAppVar.Observaciones}").ToList();

            return StatusCode(StatusCodes.Status200OK, Result1);
        }

        [HttpPost]
        [Route("U_CalificaParcialesApp")]
        public async Task<ActionResult> U_CalificaParcialesApp([FromBody] UCalifParcAppVarDTO uCalifParcAppVar)
        {

            var Result1 = new List<Respuesta>();

            Result1 = _dbContext.respuesta.FromSql($"ST_U_CalificaParcialesApp {uCalifParcAppVar.iTipoOperacion},{uCalifParcAppVar.iCalificacionID},{uCalifParcAppVar.Parcial1},{uCalifParcAppVar.Parcial2},{uCalifParcAppVar.Parcial3},{uCalifParcAppVar.PromediodeParciales},{uCalifParcAppVar.ExamenFinal},{uCalifParcAppVar.CalificacionFinal},{uCalifParcAppVar.Observaciones}").ToList();

            return StatusCode(StatusCodes.Status200OK, Result1);
        }

        [HttpPost]
        [Route("IU_GposEmpaquetados")]
        public async Task<ActionResult> IU_GposEmpaquetados([FromBody] GposEmpaquetadosVarDTO gposEmpaquetadosVar)
        {

            var Result1 = new List<Respuesta>();

            Result1 = _dbContext.respuesta.FromSql($"ST_IU_GposEmpaquetados {gposEmpaquetadosVar.iTipoOperacion},{gposEmpaquetadosVar.CarreraID},{gposEmpaquetadosVar.CicloID},{gposEmpaquetadosVar.GrupoID},{gposEmpaquetadosVar.ProfesorID},{gposEmpaquetadosVar.MateriaID}").ToList();

            return StatusCode(StatusCodes.Status200OK, Result1);
        }        


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(UsuarioDTO usuario)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbUsuario = new Usuario
                {
                    Nombre = usuario.Nombre,
                    IdRol = usuario.IdRol,
                    Correo = usuario.Correo,
                    Password = usuario.Password,
                    FechaReg = usuario.FechaReg,
                    //MatriculaID = usuario.MatriculaID,

                };

                _dbContext.Usuarios.Add(dbUsuario);
                await _dbContext.SaveChangesAsync();

                if (dbUsuario.UsuarioID != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbUsuario.UsuarioID;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No se guardo";

                }




            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

            }
            return Ok(responseApi);
        }

        [HttpPut]
        [Route("Editar/{id}")]
        public async Task<IActionResult> Editar(UsuarioDTO usuario, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {


                var dbUsuario = await _dbContext.Usuarios.FirstOrDefaultAsync(e => e.UsuarioID == id);

                if (dbUsuario != null)
                {
                    dbUsuario.Nombre = usuario.Nombre;
                    dbUsuario.IdRol = usuario.IdRol;
                    dbUsuario.Correo = usuario.Correo;
                    dbUsuario.Password = usuario.Password;

                    _dbContext.Usuarios.Update(dbUsuario);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbUsuario.UsuarioID;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No se actualizó el Usuario";

                }




            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

            }
            return Ok(responseApi);
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {


                var dbUsuario = await _dbContext.Usuarios.FirstOrDefaultAsync(e => e.UsuarioID == id);

                if (dbUsuario != null)
                {
                    _dbContext.Usuarios.Remove(dbUsuario);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No se eliminó el Usuario";

                }




            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;

            }
            return Ok(responseApi);
        }
    }
}
