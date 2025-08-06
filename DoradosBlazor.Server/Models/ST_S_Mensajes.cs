using System.ComponentModel.DataAnnotations;

namespace DoradosBlazor.Server.Models
{
    public class ST_S_Mensajes
    {
        [Key]
        public int MensajeID { get; set; }
        public string Mensaje { get; set; }
        public int UsuarioID { get; set; }
    }
}
