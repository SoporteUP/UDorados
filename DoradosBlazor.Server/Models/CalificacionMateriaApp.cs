using System.ComponentModel.DataAnnotations;

namespace DoradosBlazor.Server.Models
{
    public class CalificacionMateriaApp
    {
        [Key]

        public string MateriaID { get; set; } = null!;
        public string MatriculaID { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string CicloID { get; set; } = null!;
        public string GrupoID { get; set; } = null!;
        public string Materia { get; set; } = null!;
        public string Septiembre { get; set; } = null!;
        public string Octubre { get; set; } = null!;
        public string PromBim1 { get; set; } = null!;
        public string Noviembre { get; set; } = null!;
        public string Diciembre { get; set; } = null!;
        public string PromBim2 { get; set; } = null!;
        public string Enero { get; set; } = null!;
        public string Febrero { get; set; } = null!;
        public string PromBim3 { get; set; } = null!;
        public string Marzo { get; set; } = null!;
        public string Abril { get; set; } = null!;
        public string PromBim4 { get; set; } = null!;
        public string Mayo { get; set; } = null!;
        public string Junio { get; set; } = null!;
        public string PromBim5 { get; set; } = null!;
        public string PromedioGeneral { get; set; } = null!;
        public string Observaciones { get; set; } = null!;
    }
}
