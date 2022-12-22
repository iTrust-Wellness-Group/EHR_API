using System;
using System.Collections.Generic;

namespace EHR.Database.Entities;

public partial class ReferralFormLog
{
    public int Id { get; set; }

    public string? SharepointId { get; set; }

    public string? FormId { get; set; }

    public string? RequestId { get; set; }

    public string? MethodName { get; set; }

    public string? Section { get; set; }

    public string? QueryString { get; set; }

    public DateTime? CreateTime { get; set; }
}
