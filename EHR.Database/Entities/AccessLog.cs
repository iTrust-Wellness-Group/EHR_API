using System;
using System.Collections.Generic;

namespace EHR.Database.Entities;

public partial class AccessLog
{
    public Guid Id { get; set; }

    public Guid? ModifyUserId { get; set; }

    public string? ControllerName { get; set; }

    public string? ActionName { get; set; }

    public string? Action { get; set; }

    public string? OrignData { get; set; }

    public string? UpdateData { get; set; }

    public bool? IsDelete { get; set; }

    public DateTime CreateTime { get; set; }
}
