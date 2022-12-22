using System;
using System.Collections.Generic;

namespace EHR.Database.Entities;

public partial class Appointment
{
    public Guid Id { get; set; }

    public Guid? DrchronoAppointmentId { get; set; }

    public string? PlatformType { get; set; }

    public DateTime? ScheduledTime { get; set; }

    public Guid? PatientId { get; set; }

    public Guid? OfficeId { get; set; }

    public Guid? AccountId { get; set; }

    public string? Status { get; set; }

    public string? Note { get; set; }

    public int? ServiceType { get; set; }

    public DateTime? CreateTime { get; set; }

    public bool? IsDelete { get; set; }

    public virtual Account? Account { get; set; }

    public virtual DrchronoAppointment? DrchronoAppointment { get; set; }

    public virtual Office? Office { get; set; }

    public virtual PatientAccount? Patient { get; set; }
}
