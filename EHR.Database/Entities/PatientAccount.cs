using System;
using System.Collections.Generic;

namespace EHR.Database.Entities;

public partial class PatientAccount
{
    public Guid Id { get; set; }

    public string? Account { get; set; }

    public string? Password { get; set; }

    public string? Salt { get; set; }

    public DateTime? ActiveToken { get; set; }

    public string? RefreshTokenExpiryTime { get; set; }

    public string? RefreshToken { get; set; }

    public string? Status { get; set; }

    public DateTime? CreateTime { get; set; }

    public bool? IsDelete { get; set; }

    public string? DrchronoId { get; set; }

    public string? LeadsquaredId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();

    public virtual ICollection<PatientProfile> PatientProfiles { get; } = new List<PatientProfile>();
}
