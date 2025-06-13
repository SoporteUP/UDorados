using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoradosBlazor.Shared
{
    public class CalificacionMateriaAppVarDTO
    {
        public int iTipoConsulta { get; set; }
        public string sMatriculaID { get; set; } = null!;
        public string sGrupoID { get; set; } = null!;
        public string sCicloID { get; set; } = null!;
        public string sMateriaID { get; set; } = null!;
       
    }
}
