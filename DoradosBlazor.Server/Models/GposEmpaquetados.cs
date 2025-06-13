using System.ComponentModel.DataAnnotations;

namespace DoradosBlazor.Server.Models
{
    public class GposEmpaquetados
    {
        [Key]
        public decimal CarreraID { get; set; }
        public string CicloID { get; set; } = null!;
        public string GrupoID { get; set; } = null!;
        public int ProfesorID { get; set; } 
    }
}
