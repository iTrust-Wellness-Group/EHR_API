using System;
using System.Collections.Generic;

namespace EHR.Database.Entities;

public partial class PatientProfile
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? Phone { get; set; }

    public string? Email { get; set; }

    public string? ZipCode { get; set; }

    public string? Country { get; set; }

    public string? State { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public DateTime? CreateTime { get; set; }

    public string? Result { get; set; }

    public Guid? PatientId { get; set; }

    public virtual PatientAccount? Patient { get; set; }
}
