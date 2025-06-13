using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoradosBlazor.Shared
{
    public class CiclosDTO
    {
        public string CicloID { get; set; } = null!;
        public decimal CarreraID { get; set; } 
        public string Carrera { get; set; } = null!;        
        public DateTime fechaInsc { get; set; } = DateTime.Today;
        public string TipoCiclo { get; set; } = null!;

    }
}


