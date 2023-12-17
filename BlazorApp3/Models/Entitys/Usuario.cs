using System;
using System.Collections.Generic;

namespace BlazorApp3.Models.Entitys;

public partial class Usuario
{
    public int Userid { get; set; }

    public string? Username { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public sbyte? Verificado { get; set; }

    public string? Contrasenia { get; set; }
}
