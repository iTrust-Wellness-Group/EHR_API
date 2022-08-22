using System;
using System.Collections.Generic;

namespace EHR.Database.Entities
{
    public partial class Page
    {
        public Page()
        {
            Permissions = new HashSet<Permission>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
