using System;
using System.Collections.Generic;

namespace BlazorApp3.Models.Entitys;

public partial class Modulo
{
    public int Moduloid { get; set; }

    public string? Nombre { get; set; }

    public string? Codigo { get; set; }

    public string? Enlace { get; set; }

    public sbyte? Tienecuestionario { get; set; }

    public virtual ICollection<ModuloDet> ModuloDets { get; set; } = new List<ModuloDet>();

    public virtual ICollection<Pregunta> Pregunta { get; set; } = new List<Pregunta>();

    public virtual ICollection<Respuesta> Respuesta { get; set; } = new List<Respuesta>();
}
