using System.ComponentModel.DataAnnotations;

namespace DoradosBlazor.Server.Models
{
    public class ST_S_CARRERAS
    {
        [Key]
        public decimal CarreraID { get; set; }
        public string IncorporacionID { get; set; }
        public decimal NivelEducativoID { get; set; }
        public string? Carrera { get; set; }
        public string? Nivel { get; set; }
        public decimal? AñodelPlan { get; set; }
        public string? Vigente { get; set; }
        public double? Inscripcion { get; set; }
        public double? Mensualidad { get; set; }
        public string? TipoCiclo { get; set; }
    }
}
