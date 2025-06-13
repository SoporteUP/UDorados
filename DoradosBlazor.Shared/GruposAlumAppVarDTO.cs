using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoradosBlazor.Shared
{
    public class GruposAlumAppVarDTO
    {
        public int iTipoConsulta { get; set; }
        public decimal iCarreraID { get; set; } 
        public string sCicloID { get; set; } = null!;
        public string sGrupoID { get; set; } = null!;
    }
}
