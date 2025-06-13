namespace DoradosBlazor.Server.Models
{
    public partial class Usuario
    {
        public int UsuarioID { get; set; }

        public string Nombre { get; set; } = null!;

        public int IdRol { get; set; } 

        public string Correo { get; set; } = null!;

        public string Password { get; set; } = null!;
        
        public DateTime FechaReg { get; set; }

        public int MatriculaID { get; set; }

        public virtual Roles IdRolesNavigation { get; set; } = null!;
    }
}
