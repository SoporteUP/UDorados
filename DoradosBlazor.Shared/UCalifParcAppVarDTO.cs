using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoradosBlazor.Shared
{
    public class UCalifParcAppVarDTO
    {
        public int iTipoOperacion { get; set; }
        public decimal iCalificacionID { get; set; }
        public string Parcial1 { get; set; } = null!;
        public string Parcial2 { get; set; } = null!;
        public string Parcial3 { get; set; } = null!;
        public string PromediodeParciales { get; set; } = null!;
        public string ExamenFinal { get; set; } = null!;
        public string CalificacionFinal { get; set; } = null!;
        public string Observaciones { get; set; } = null!;
    }
}
