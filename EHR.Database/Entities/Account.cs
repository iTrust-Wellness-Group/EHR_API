﻿using System;
using System.Collections.Generic;

namespace EHR.Database.Entities;

public partial class Account
{
    public Guid Id { get; set; }

    public string? Account1 { get; set; }

    public string? Password { get; set; }

    public string? Salt { get; set; }

    public string? ActiveToken { get; set; }

    public string? RefreshTokenExpiryTime { get; set; }

    public string? RefreshToken { get; set; }

    public short? Status { get; set; }

    public DateTime? CreateTime { get; set; }

    public bool? IsDelete { get; set; }

    public string? DrchonoId { get; set; }

    public virtual ICollection<AccountRoleMap> AccountRoleMaps { get; } = new List<AccountRoleMap>();

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();
}
