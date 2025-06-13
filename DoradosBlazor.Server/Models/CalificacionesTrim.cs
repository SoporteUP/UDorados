using System.ComponentModel.DataAnnotations;
namespace DoradosBlazor.Server.Models
{
    public class CalificacionesTrim
    {
        [Key]

        public decimal CarreraID { get; set; }
        public string Carrera { get; set; } = null!;
        public string CicloID { get; set; } = null!;
        public string GrupoID { get; set; } = null!;
        public string MateriaID { get; set; } = null!;
        public string Materia { get; set; } = null!;
        public string MatriculaID { get; set; } = null!;
        public string Alumno { get; set; } = null!;
        public string Septiembre { get; set; } = null!;
        public int F1 { get; set; }
        public string Octubre { get; set; } = null!;
        public int F2 { get; set; }
        public string Noviembre { get; set; } = null!;
        public int F3 { get; set; }
        public string Prom1 { get; set; } = null!;
        public string DicEne { get; set; } = null!;
        public int F4 { get; set; }
        public string Febrero { get; set; } = null!;
        public int F6 { get; set; }
        public string Marzo { get; set; } = null!;
        public int F7 { get; set; }
        public string Prom2 { get; set; } = null!;
        public string Abril { get; set; } = null!;
        public int F8 { get; set; }
        public string Mayo { get; set; } = null!;
        public int F9 { get; set; }
        public string Junio { get; set; } = null!;
        public int F10 { get; set; }
        public string Prom3 { get; set; } = null!;
        public int PromedioGeneral { get; set; }
    }
}
