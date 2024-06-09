using System;
using System.Collections.Generic;

namespace ProyectoFinal.Entities;

public partial class RegistroDetalle
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public string NumeroAdicional { get; set; } = null!;
}
