using System;
using System.Collections.Generic;

namespace EHR.Database.Entities;

public partial class AutomationLog
{
    public int Id { get; set; }

    public DateTime? Timestamp { get; set; }

    public string? PatientId { get; set; }

    public string? Other { get; set; }
}
