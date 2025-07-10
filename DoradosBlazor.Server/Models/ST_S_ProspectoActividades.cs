using System.ComponentModel.DataAnnotations;

namespace DoradosBlazor.Server.Models
{
    public class ST_S_ProspectoActividades
    {
        [Key]
        public int ActividadID { get; set; }
        public int ProspectoID { get; set; }
        public int EjecutivoID { get; set; }
        public string? Tipo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaProgramada { get; set; }
        public bool Realizado { get; set; }
    }
}
