using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace DoradosBlazor.Shared
{
    public class UsuarioDTO
    {
        public int UsuarioID { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Nombre { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido.")]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Correo { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Password { get; set; } = null!;

        public DateTime FechaReg { get; set; }

        public string MatriculaID { get; set; }

        public RolesDTO? Roles { get; set; }

    }
}
