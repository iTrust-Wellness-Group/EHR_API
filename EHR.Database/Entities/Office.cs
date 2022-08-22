using System;
using System.Collections.Generic;

namespace EHR.Database.Entities
{
    public partial class Office
    {
        public Office()
        {
            AccountProfiles = new HashSet<AccountProfile>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<AccountProfile> AccountProfiles { get; set; }
    }
}
