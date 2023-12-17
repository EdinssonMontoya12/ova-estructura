using System;
using System.Collections.Generic;

namespace BlazorApp3.Models.Entitys;

public partial class Pregunta
{
    public int Preguntaid { get; set; }

    public int Moduloid { get; set; }

    public int? Numero { get; set; }

    public string? Pregunta1 { get; set; }

    public string? Correcta { get; set; }

    public virtual Modulo Modulo { get; set; } = null!;

    public virtual ICollection<OpcionesPregunta> OpcionesPregunta { get; set; } = new List<OpcionesPregunta>();

    public virtual ICollection<Respuesta> Respuesta { get; set; } = new List<Respuesta>();
}
