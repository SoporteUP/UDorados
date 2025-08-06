using System.ComponentModel.DataAnnotations;

namespace DoradosBlazor.Server.Models
{
    public class ST_S_PreEnvios
    {
        [Key]
        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public int UsuarioID { get; set; }
        public double? Delay { get; set; }
        public string? Mensaje { get; set; }
        public string? Instancia { get; set; }
        public string? ApiKey { get; set; }
        public bool? Usado { get; set; }
        public string? Status { get; set; }
    }
}
