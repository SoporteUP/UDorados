using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoradosBlazor.Shared
{
    public class AdeudosVarDTO
    {
        public int iTipoOperacion { get; set; }
        public string sMatricula { get; set; } = null!;
        public DateTime dFechaIni { get; set; }
        public DateTime dFechaFin { get; set; } 
    }
}
