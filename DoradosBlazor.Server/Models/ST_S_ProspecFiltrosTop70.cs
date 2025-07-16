using System.ComponentModel.DataAnnotations;

namespace DoradosBlazor.Server.Models
{
    public class ST_S_ProspecFiltrosTop70
    {
        [Key]
        public int ProspectoID { get; set; }
        public int EjecutivoID { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Celular { get; set; }
        public string? Correo { get; set; }
        public string? Localidad { get; set; }
        public string? AreaInteres { get; set; }
        public string? EscuelaProcedencia { get; set; }
        public string? CicloEscolar { get; set; }
        public decimal? Edad { get; set; }
        public string? MedioseEntero { get; set; }
        public string? QuienAtendio { get; set; }
        public string? Estatus { get; set; }
        public string? Llamo { get; set; }
        public string? Ubicacion { get; set; }
        public string? Facebook { get; set; }
        public string? Niv_AcademicoInteres { get; set; }
        public string? Base { get; set; }
        public string? Turno { get; set; }
        public string? Institu_Evento { get; set; }
    }
}
