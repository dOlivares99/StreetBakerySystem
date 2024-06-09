using System;
using System.Collections.Generic;

namespace ProyectoFinal.Entities;

public partial class AdminBaker
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Soruce { get; set; } = null!;
}
