using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoradosBlazor.Shared
{
    public class MateriasProfesoresDTO
    {
        public string MateriaID { get; set; } = null!;
        public decimal ProfesorID { get; set; }
        public string Profesor { get; set; }
        public decimal CarreraID { get; set; } 
        public string Carrera { get; set; } = null!;       
        public string Materia { get; set; } = null!;      
        public string CicloID { get; set; } = null!;
        public string GrupoID { get; set; } = null!;
    }
}
