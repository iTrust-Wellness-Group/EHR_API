using System;
using System.Collections.Generic;

namespace EHR.Database.Entities;

public partial class AutomationAuditLog
{
    public int Id { get; set; }

    public int? Version { get; set; }

    public DateTime? Timestamp { get; set; }

    public string? ApiUser { get; set; }

    public string? DatabaseUser { get; set; }

    /// <summary>
    /// IP where request originated
    /// </summary>
    public string? RequestIp { get; set; }

    /// <summary>
    /// Server IP that processed the request
    /// </summary>
    public string? ServerIp { get; set; }

    public string? PatientId { get; set; }

    public string? AppointmentId { get; set; }

    public string? OriginalData { get; set; }

    public string? NewData { get; set; }

    public string? Event { get; set; }
}
