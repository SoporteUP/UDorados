using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoradosBlazor.Shared
{
    public class CalificacionAlumAppVarDTO
    {
        public int iTipoConsulta { get; set; }
        public string sMatriculaID { get; set; } = null!;
        public string sGrupoID { get; set; }
        public string sCicloID { get; set; }
        public string Email { get; set; } = null!;
        public string MateriaID { get; set; } = null!;

    }
}
