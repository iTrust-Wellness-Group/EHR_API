﻿using System;
using System.Collections.Generic;

namespace EHR.Database.Entities;

public partial class Office
{
    public Guid Id { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? DrchronoId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();
}
