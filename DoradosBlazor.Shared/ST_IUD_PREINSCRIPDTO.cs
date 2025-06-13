using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoradosBlazor.Shared
{
    public class ST_IUD_PREINSCRIPDTO
    {
        public int iTipoOperacion { get; set; }
        public string sMatriculaID { get; set; }
        public int? sCarreraID { get; set; }
        public DateTime dFecha { get; set; }
        public decimal? fBecaDesc { get; set; }
        public decimal fColegiatura { get; set; }
        public string? sUsuario { get; set; }
        public string? sMedioEntero { get; set; }
        public decimal? fAbono { get; set; }
        public string? sCicloID { get; set; }
    }
}
