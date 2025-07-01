using DoradosBlazor.Shared;

namespace DoradosBlazor.Client.Services
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> Lista();

        Task<List<CiclosDTO>> ListaCiclos(CiclosVarDTO ciclosVar);
        Task<List<CaliParcDTO>> ListaCaliParc(CalifVarDTO califVar);
        Task<List<CaliMensDTO>> ListaCaliMens(CalifVarDTO califVar);
        Task<List<AdeudosAlumDTO>> ListaAdeudosAlum(AdeudosVarDTO adeudosVar);
        Task<List<ConAdeudoDTO>> ListaConAdeudo(AdeudosVarDTO adeudosVar);
        Task<List<TotalAdeudosDTO>> TotalAdeudos(AdeudosVarDTO adeudosVar);
        Task<List<MateriasProfesoresDTO>> ListaMateriasProfesores(MateriasProfesoresVar materiasProfesoresVar);
        Task<List<GruposAlumAppDTO>> ListaGruposAlumApp(GruposAlumAppVarDTO gruposAlumAppVar);
        Task<List<CalificacionAlumAppDTO>> ListaCalificacionAlumApp(CalificacionAlumAppVarDTO calificacionAlumAppVar);
        Task<List<CalificacionParcAlumAppDTO>> ListaCalificacionParcAlumApp(CalificacionAlumAppVarDTO calificacionAlumAppVar);
        Task<List<CalificacionMateriaAppDTO>> ListaCalificacionMateriaApp(CalificacionMateriaAppVarDTO calificacionMateriaAppVar);              
        Task<List<ST_S_GposEmpaquetadosDTO>> ListaGposEmpaquetados(ST_S_GposEmpaquetadosVarDTO sT_S_GposEmpaquetadosVarDTO);
        Task<List<ST_S_GposEmpaquetadosListosDTO>> ListaGposEmpaquetadosListos(ST_S_GposEmpaquetadosVarDTO sT_S_GposEmpaquetadosVarDTO);
        Task<List<ST_S_PREINSCRIPDTO>> ST_S_PREINSCRIP(int iTipoConsulta, string sUsuario, int iMatriculaID, string sNombre);
        Task<List<ST_S_PREINSCRIPCOUNTDTO>> ST_S_PREINSCRIPCOUNT(int iTipoConsulta, string sUsuario, int iMatriculaID, string sNombre);
        Task<List<ST_S_CARRERASDTO>> ST_S_CARRERAS(int iTipoConsulta, string sCarrera);
        Task<List<ST_S_PREINSC_INCOMPDTO>> ST_S_PREINSC_INCOMP(int iTipoConsulta, string sNombre);
        Task<List<ST_S_DatosPDFDTO>> ST_S_DatosPDF(int iTipoConsulta, string iID);
        Task<List<ST_S_CorreosMisCuentasDTO>> ST_S_CorreosMisCuentas(int iTipoConsulta, string sCorreo);
        Task<UsuarioDTO>Buscar(int id); 

        Task<int>Guardar(UsuarioDTO usuario);

        Task<int> Editar(UsuarioDTO usuario);

        Task<bool> Eliminar(int id);

    }
}
