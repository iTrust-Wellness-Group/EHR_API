using System;
using System.Collections.Generic;

namespace EHR.Database.Entities;

public partial class DrchronoAppointment
{
    public Guid Id { get; set; }

    public string? DrchronoId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();
}
