using System;
using System.Collections.Generic;

namespace EHR.Database.Entities;

public partial class DrchronoIdLookup
{
    public int Id { get; set; }

    public string? DrchronoId { get; set; }

    public string? Phone { get; set; }
}
