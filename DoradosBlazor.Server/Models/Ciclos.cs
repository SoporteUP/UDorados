using System.ComponentModel.DataAnnotations;

namespace DoradosBlazor.Server.Models
{
    public partial class Ciclos
    {
        [Key]
        public string CicloID { get; set; } = null!;
        public decimal CarreraID { get; set; } 
        public string Carrera { get; set; } = null!;
        public DateTime fechaInsc { get; set; }
        public string TipoCiclo { get; set; } = null!;
    }
}
