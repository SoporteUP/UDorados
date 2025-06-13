using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoradosBlazor.Shared
{
    public class CalificacionParcAlumAppDTO
    {
        public decimal CalificacionID { get; set; }
        public string MateriaID { get; set; } = null!;
        public string MatriculaID { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string CicloID { get; set; } = null!;
        public string GrupoID { get; set; } = null!;
        public string Materia { get; set; } = null!;
        public string Parcial1 { get; set; } = null!;
        public string Parcial2 { get; set; } = null!;
        public string Parcial3 { get; set; } = null!;
        public string PromediodeParciales { get; set; } = null!;
        public string ExamenFinal { get; set; } = null!;
        public string CalificacionFinal { get; set; } = null!;      
        public string Observaciones { get; set; } = null!;
    }
}
