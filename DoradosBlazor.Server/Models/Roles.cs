namespace DoradosBlazor.Server.Models
{
    public partial class Roles
    {
        public int IdRol { get; set; }

        public string NombreRol { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
    }
}
