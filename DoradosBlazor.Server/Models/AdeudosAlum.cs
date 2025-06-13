using System.ComponentModel.DataAnnotations;
namespace DoradosBlazor.Server.Models
{
   
    public class AdeudosAlum
    {
        [Key]
        public decimal ColegiaturaTramiteID { get; set; }
        public decimal CarreraID { get; set; }
        public string CicloID { get; set; } = null!;
        public string GrupoID { get; set; } = null!;
        public string MatriculaID { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public DateTime FechaApagar { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int DiasMorosos { get; set; } = 0;
        public double Importe { get; set; } = 0;
        public double ImporteBecaDesc { get; set; } = 0;
        public double ImporteRecargos { get; set; } = 0;
        public double ImporteTotal { get; set; } = 0;
        public double Abono { get; set; } = 0;
        public double Saldo { get; set; } = 0;
        public string Alumno { get; set; } = null!;
        public string Carrera { get; set; } = null!;
    }
}
