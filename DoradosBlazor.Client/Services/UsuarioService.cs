using DoradosBlazor.Shared;
using System.Net.Http.Json;

namespace DoradosBlazor.Client.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly HttpClient _http;

        public UsuarioService(HttpClient http)
        {
            _http = http;
        }


        public async Task<List<UsuarioDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<UsuarioDTO>>>("api/Usuario/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<List<CiclosDTO>> ListaCiclos(CiclosVarDTO ciclosVar)
        {
            var result = await _http.PostAsJsonAsync("api/Usuario/ListaCiclos", ciclosVar);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<List<CiclosDTO>>>();


            return response.Valor;

        }

        public async Task<List<CaliParcDTO>> ListaCaliParc(CalifVarDTO califVar)
        {
            var result = await _http.PostAsJsonAsync("api/Usuario/ListaCaliParc", califVar);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<List<CaliParcDTO>>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<List<CaliMensDTO>> ListaCaliMens(CalifVarDTO califVar)
        {
            var result = await _http.PostAsJsonAsync("api/Usuario/ListaCaliMens", califVar);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<List<CaliMensDTO>>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<List<AdeudosAlumDTO>> ListaAdeudosAlum(AdeudosVarDTO adeudosVar)
        {
            var result = await _http.PostAsJsonAsync("api/Usuario/ListaAdeudosAlum", adeudosVar);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<List<AdeudosAlumDTO>>>();


            return response.Valor;
        }

        public async Task<List<ConAdeudoDTO>> ListaConAdeudo(AdeudosVarDTO adeudosVar)
        {
            var result = await _http.PostAsJsonAsync("api/Usuario/ListaConAdeudo", adeudosVar);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<List<ConAdeudoDTO>>>();


            return response.Valor;
        }

        public async Task<List<TotalAdeudosDTO>> TotalAdeudos(AdeudosVarDTO adeudosVar)
        {
            var result = await _http.PostAsJsonAsync("api/Usuario/TotalAdeudos", adeudosVar);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<List<TotalAdeudosDTO>>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else

                throw new Exception(response.Mensaje);

        }


        public async Task<List<MateriasProfesoresDTO>> ListaMateriasProfesores(MateriasProfesoresVar materiasProfesoresVar)
        {
            var result = await _http.PostAsJsonAsync("api/Usuario/ListaMateriasProfesores", materiasProfesoresVar);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<List<MateriasProfesoresDTO>>>();


            return response.Valor;
        }

        public async Task<List<GruposAlumAppDTO>> ListaGruposAlumApp(GruposAlumAppVarDTO gruposAlumAppVar)
        {
            var result = await _http.PostAsJsonAsync("api/Usuario/ListaGruposAlumApp", gruposAlumAppVar);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<List<GruposAlumAppDTO>>>();


            return response.Valor;
        }


        public async Task<List<CalificacionAlumAppDTO>> ListaCalificacionAlumApp(CalificacionAlumAppVarDTO calificacionAlumAppVar)
        {
            var result = await _http.PostAsJsonAsync("api/Usuario/ListaCalificacionAlumApp", calificacionAlumAppVar);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<List<CalificacionAlumAppDTO>>>();


            return response.Valor;
        }

        public async Task<List<CalificacionParcAlumAppDTO>> ListaCalificacionParcAlumApp(CalificacionAlumAppVarDTO calificacionAlumAppVar)
        {
            var result = await _http.PostAsJsonAsync("api/Usuario/ListaCalificacionParcAlumApp", calificacionAlumAppVar);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<List<CalificacionParcAlumAppDTO>>>();


            return response.Valor;
        }


        public async Task<List<CalificacionMateriaAppDTO>> ListaCalificacionMateriaApp(CalificacionMateriaAppVarDTO calificacionMateriaAppVar)
        { 
            var result = await _http.PostAsJsonAsync("api/Usuario/ListaCalificacionMateriaApp", calificacionMateriaAppVar);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<List<CalificacionMateriaAppDTO>>>();


            return response.Valor;
        }

        public async Task<List<ST_S_GposEmpaquetadosDTO>> ListaGposEmpaquetados(ST_S_GposEmpaquetadosVarDTO sT_S_GposEmpaquetadosVarDTO)
        {
            var result = await _http.PostAsJsonAsync("api/Usuario/ListaGposEmpaquetados", sT_S_GposEmpaquetadosVarDTO);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<List<ST_S_GposEmpaquetadosDTO>>>();


            return response.Valor;
        }


        public async Task<List<ST_S_GposEmpaquetadosListosDTO>> ListaGposEmpaquetadosListos(ST_S_GposEmpaquetadosVarDTO sT_S_GposEmpaquetadosVarDTO)
        {
            var result = await _http.PostAsJsonAsync("api/Usuario/ListaGposEmpaquetadosListos", sT_S_GposEmpaquetadosVarDTO);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<List<ST_S_GposEmpaquetadosListosDTO>>>();


            return response.Valor;
        }



        public async Task<UsuarioDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<UsuarioDTO>>($"api/Usuario/Buscar/{id}");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<MatriculaDTO> SiExisteMatricula(int matriculaID)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<MatriculaDTO>>($"api/Usuario/SiExisteMatricula/{matriculaID}");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        
        public async Task<int> Guardar(UsuarioDTO usuario)
        {
            var result = await _http.PostAsJsonAsync("api/Usuario/Guardar", usuario);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<int> Editar(UsuarioDTO usuario)
        {
            var result = await _http.PutAsJsonAsync($"api/Usuario/Editar/{usuario.UsuarioID}", usuario);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Usuario/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.EsCorrecto!;
            else
                throw new Exception(response.Mensaje);
        }


        public async Task<List<ST_S_PREINSCRIPDTO>> ST_S_PREINSCRIP(int iTipoConsulta, string sUsuario, int iMatriculaID, string sNombre)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<ST_S_PREINSCRIPDTO>>>($"api/Usuario/ST_S_PREINSCRIP/{iTipoConsulta}/{sUsuario}/{iMatriculaID}/{sNombre}");
            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
        public async Task<List<ST_S_PREINSCRIPCOUNTDTO>> ST_S_PREINSCRIPCOUNT(int iTipoConsulta, string sUsuario, int iMatriculaID, string sNombre)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<ST_S_PREINSCRIPCOUNTDTO>>>($"api/Usuario/ST_S_PREINSCRIPCOUNT/{iTipoConsulta}/{sUsuario}/{iMatriculaID}/{sNombre}");
            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<List<ST_S_CARRERASDTO>> ST_S_CARRERAS(int iTipoConsulta, string sCarrera)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<ST_S_CARRERASDTO>>>($"api/Usuario/ST_S_CARRERAS/{iTipoConsulta}/{sCarrera}");
            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }


        public async Task<List<ST_S_PREINSC_INCOMPDTO>> ST_S_PREINSC_INCOMP(int iTipoConsulta, string sNombre)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<ST_S_PREINSC_INCOMPDTO>>>($"api/Usuario/ST_S_PREINSC_INCOMP/{iTipoConsulta}/{sNombre}");
            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<List<ST_S_DatosPDFDTO>> ST_S_DatosPDF(int iTipoConsulta, string iID)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<ST_S_DatosPDFDTO>>>($"api/Usuario/ST_S_DatosPDF/{iTipoConsulta}/{iID}");
            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<List<ST_S_CorreosMisCuentasDTO>> ST_S_CorreosMisCuentas(int iTipoConsulta, string sCorreo)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<ST_S_CorreosMisCuentasDTO>>>($"api/Usuario/ST_S_CorreosMisCuentas/{iTipoConsulta}/{sCorreo}");
            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<List<ST_S_ProspecFiltrosDTO>> ST_S_ProspecFiltros(string cCampo, string cBusqueda, string cCampo2, string cBusqueda2)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<ST_S_ProspecFiltrosDTO>>>($"api/Usuario/ST_S_ProspecFiltros/{cCampo}/{cBusqueda}/{cCampo2}/{cBusqueda2}");
            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<List<ST_S_ProspecFiltrosTop70DTO>> ST_S_ProspecFiltrosTop70(string cCampo, string cBusqueda, string cCampo2, string cBusqueda2)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<ST_S_ProspecFiltrosTop70DTO>>>($"api/Usuario/ST_S_ProspecFiltrosTop70/{cCampo}/{cBusqueda}/{cCampo2}/{cBusqueda2}");
            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }


        public async Task<List<ST_S_ProspectoActividadesDTO>> ST_S_ProspectoActividades(int iTipoOperacion, int iProspectoID, int iEjecutivoID)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<ST_S_ProspectoActividadesDTO>>>($"api/Usuario/ST_S_ProspectoActividades/{iTipoOperacion}/{iProspectoID}/{iEjecutivoID}");
            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<List<ST_S_ProspectoActividadesDTO>> ST_S_ProspectoActividadesAll()
        {
            var response = await _http.GetFromJsonAsync<ResponseAPI<List<ST_S_ProspectoActividadesDTO>>>("/api/Usuario/ST_S_ProspectoActividadesAll");
            return response != null && response.EsCorrecto ? response.Valor : new List<ST_S_ProspectoActividadesDTO>();
        }


    }
}

