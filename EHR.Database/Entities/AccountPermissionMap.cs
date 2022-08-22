using System;
using System.Collections.Generic;

namespace EHR.Database.Entities
{
    public partial class AccountPermissionMap
    {
        public Guid Id { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? PermissionId { get; set; }
        public bool? IsDisabled { get; set; }
        public DateTime CreateTime { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Permission? Permission { get; set; }
    }
}
