using System.ComponentModel.DataAnnotations;

namespace DoradosBlazor.Server.Models
{
    public class ST_S_CorreosMisCuentas
    {
        [Key]
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        public string smtp { get; set; }
        public int Puerto { get; set; }
        public bool Predeterminado { get; set; }
    }
}
