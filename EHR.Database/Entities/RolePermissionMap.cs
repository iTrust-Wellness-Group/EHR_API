using System;
using System.Collections.Generic;

namespace EHR.Database.Entities;

public partial class RolePermissionMap
{
    public Guid Id { get; set; }

    public Guid? RoleId { get; set; }

    public Guid? PermissionId { get; set; }

    public DateTime CreateTime { get; set; }

    public bool? IsDelete { get; set; }

    public virtual Permission? Permission { get; set; }
}
