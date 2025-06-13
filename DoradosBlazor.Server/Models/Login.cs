using System.ComponentModel.DataAnnotations;

namespace DoradosBlazor.Server.Models
{
    public partial class Login
    {
        [Key]
        public int UsuarioID { get; set; }  // must be public!
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; }
        public string NombreRol { get; set; }
        public string MatriculaID { get; set; }

    }
}
