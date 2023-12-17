using System;
using System.Collections.Generic;

namespace BlazorApp3.Models.Entitys;

public partial class ModuloDet
{
    public int Modulodet1 { get; set; }

    public int? Moduloid { get; set; }

    public string? Userid { get; set; }

    public decimal? Porcentaje { get; set; }

    public virtual Modulo? Modulo { get; set; }

    public virtual AspNetUser? User { get; set; }
}
