using System;
using System.Collections.Generic;

namespace BlazorApp3.Models.Entitys;

public partial class EfmigrationsHistory
{
    public string MigrationId { get; set; } = null!;

    public string ProductVersion { get; set; } = null!;
}
