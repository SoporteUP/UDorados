using System.ComponentModel.DataAnnotations;

namespace DoradosBlazor.Server.Models
{
    public class ST_S_PREINSC_INCOMP
    {
        [Key]
        public int MatriculaID { get; set; }
        public string Nombre { get; set; }
        public string Apellido_paterno { get; set; }
        public string Apellido_materno { get; set; }
        public int? Edad { get; set; }
        public string? Direccion { get; set; }
        public string? Colonia { get; set; }
        public string? Ciudad { get; set; }
        public int? CodigoPostal { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? EscuelaProcedencia { get; set; }
        public string? LugardeNacimiento { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Ocupacion { get; set; }
        public string? Sector { get; set; }
        public string? ServicioMedico { get; set; }
        public string? Curp { get; set; }
        public int? CarreraID { get; set; }
        public string? Carrera { get; set; }
        public DateTime fechaInsc { get; set; }
        public int? ID { get; set; }
        public string? Atendio { get; set; }
        public string? CicloID { get; set; }
        public string? MedioEntero { get; set; }
        public string? NombreTutor { get; set; }
        public string? APTutor { get; set; }
        public string? AMTutor { get; set; }
        public string? OcupacionTutor { get; set; }
        public string? ParentescoTutor { get; set; }
        public string? TelTutor { get; set; }
        public string? CorreoTutor { get; set; }
        public string? DireccionTutor { get; set; }
        public string? CasoEmergencia { get; set; }
        public string? Parentesco { get; set; }
        public string? TelEmergencia { get; set; }
        public string? CorreoEmergencia { get; set; }
    }
}
