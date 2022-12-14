using System;
using System.Collections.Generic;

namespace EHR.Database.Entities
{
    public partial class AccountRoleMap
    {
        public Guid Id { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? RoleId { get; set; }
        public int? Operate { get; set; }
        public DateTime CreateTime { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Role? Role { get; set; }
    }
}
