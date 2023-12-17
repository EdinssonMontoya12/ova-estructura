using System;
using System.Collections.Generic;

namespace BlazorApp3.Models.Entitys;

public partial class Respuesta
{
    public int Respuestaid { get; set; }

    public string? Userid { get; set; }

    public int? Moduloid { get; set; }

    public int? Preguntaid { get; set; }

    public int? Opcionid { get; set; }

    public sbyte? Correcta { get; set; }

    public virtual Modulo? Modulo { get; set; }

    public virtual OpcionesPregunta? Opcion { get; set; }

    public virtual Pregunta? Pregunta { get; set; }

    public virtual AspNetUser? User { get; set; }
}
