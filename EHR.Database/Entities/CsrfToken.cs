using System;
using System.Collections.Generic;

namespace EHR.Database.Entities;

public partial class CsrfToken
{
    public int Id { get; set; }

    public string? LeadId { get; set; }

    public string? Token { get; set; }

    public double? Expiry { get; set; }
}
