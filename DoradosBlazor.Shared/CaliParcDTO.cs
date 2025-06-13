using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoradosBlazor.Shared
{
    public class CaliParcDTO
    {
        public string MateriaID { get; set; } = null!;
        public decimal CarreraID { get; set; } 
        public string Carrera { get; set; } = null!;
        public string CicloID { get; set; } = null!;
        public string GrupoID { get; set; } = null!;        
        public string Materia { get; set; } = null!;
        public string MatriculaID { get; set; } = null!;
        public string Alumno { get; set; } = null!;
        public string Parcial1 { get; set; } = null!;
        public int F1 { get; set; }
        public string Parcial2 { get; set; } = null!;
        public int F2 { get; set; }
        public string Parcial3 { get; set; } = null!;
        public int F3 { get; set; }
        public string PromediodeParciales { get; set; } = null!;
        public string ExamenFinal { get; set; } = null!;
        public string CalificacionFinal { get; set; } = null!;
        public string Observaciones { get; set; } = null!;

    }
}
