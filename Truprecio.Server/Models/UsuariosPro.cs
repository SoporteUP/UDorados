using System;
using System.Collections.Generic;

namespace Truprecio.Server.Models;

public partial class UsuariosPro
{
    public int UsuarioId { get; set; }

    public string? Correo { get; set; }

    public string? Password { get; set; }

    public string? CorreoRecuperacion { get; set; }

    public DateOnly? FechaPago { get; set; }

    public DateOnly? FechaVencimiento { get; set; }
}
