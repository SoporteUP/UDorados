using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoradosBlazor.Shared
{
    public class ST_S_ProspectoActividadesDTO
    {
        public int ActividadID { get; set; }
        public int ProspectoID { get; set; }
        public int EjecutivoID { get; set; }
        public string? Tipo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaProgramada { get; set; }
        public bool Realizado { get; set; }
        public string? NombreProspecto { get; set; }
    }
}
