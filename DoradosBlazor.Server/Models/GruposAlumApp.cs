using System.ComponentModel.DataAnnotations;

namespace DoradosBlazor.Server.Models
{
    public class GruposAlumApp
    {
        [Key]
        public string MatriculaID { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string GrupoID { get; set; } = null!;
        public string CicloID { get; set; } = null!;
    }
}
