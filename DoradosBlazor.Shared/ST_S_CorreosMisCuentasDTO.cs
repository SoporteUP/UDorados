using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoradosBlazor.Shared
{
    public class ST_S_CorreosMisCuentasDTO
    { 
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
