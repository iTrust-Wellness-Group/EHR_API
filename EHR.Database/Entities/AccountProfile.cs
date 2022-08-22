using System;
using System.Collections.Generic;

namespace EHR.Database.Entities
{
    public partial class AccountProfile
    {
        public Guid Id { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? OfficeId { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public DateTime CreateTime { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Office? Office { get; set; }
    }
}
