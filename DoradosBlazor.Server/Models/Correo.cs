using System.ComponentModel.DataAnnotations;

namespace DoradosBlazor.Server.Models
{
    public partial class Correo
    {
        [Key]
        public string Email { get; set; }
        public int ExisteCorreo { get; set; }
    }
}
