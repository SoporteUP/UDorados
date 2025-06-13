using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoradosBlazor.Shared
{
    public class GposEmpaquetadosVarDTO
    {
        public int iTipoOperacion { get; set; }
        public decimal CarreraID { get; set; }
        public string CicloID { get; set; } = null!;
        public string GrupoID { get; set; } = null!;
        public int ProfesorID { get; set; }
        public string MateriaID { get; set; }
    }
}
