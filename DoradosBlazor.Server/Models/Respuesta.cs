using System.ComponentModel.DataAnnotations;

namespace DoradosBlazor.Server.Models
{
    public partial class Respuesta
    {
        [Key]
        public string Mensaje { get; set; } = null!;
    }
}
