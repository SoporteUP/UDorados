using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoradosBlazor.Shared
{
    public class ST_S_PreEnviosDTO
    {
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
