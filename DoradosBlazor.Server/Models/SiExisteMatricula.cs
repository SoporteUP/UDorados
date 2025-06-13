using System.ComponentModel.DataAnnotations;

namespace DoradosBlazor.Server.Models
{
    public partial class SiExisteMatricula
    {

        [Key]
        public string MatriculaID { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public int RolID { get; set; }
    }
}
