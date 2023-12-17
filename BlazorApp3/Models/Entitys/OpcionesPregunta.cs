using System;
using System.Collections.Generic;

namespace BlazorApp3.Models.Entitys;

public partial class OpcionesPregunta
{
    public int Opcionid { get; set; }

    public string? LetraOpcion { get; set; }

    public string? ContenidoOpcion { get; set; }

    public int Preguntaid { get; set; }

    public virtual Pregunta Pregunta { get; set; } = null!;

    public virtual ICollection<Respuesta> Respuesta { get; set; } = new List<Respuesta>();
}
