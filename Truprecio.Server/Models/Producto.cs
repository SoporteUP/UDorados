using System;
using System.Collections.Generic;

namespace Truprecio.Server.Models;

public partial class Producto
{
    public string? Codigo { get; set; }

    public string? Descripcion { get; set; }

    public string? Unidad { get; set; }

    public string? Clave { get; set; }

    public string? CodBarras { get; set; }

    public double? Caja { get; set; }

    public double? Master { get; set; }

    public string? ProdServisId { get; set; }

    public string? MedidaId { get; set; }

    public double? PesoEnKg { get; set; }

    public double? Publico { get; set; }

    public double? Mayoreo { get; set; }

    public double? Subdistribuidor { get; set; }

    public double? Distribuidor { get; set; }

    public string? Imagen { get; set; }
}
