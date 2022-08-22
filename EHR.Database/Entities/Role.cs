using System;
using System.Collections.Generic;

namespace EHR.Database.Entities
{
    public partial class Role
    {
        public Role()
        {
            AccountRoleMaps = new HashSet<AccountRoleMap>();
            RolePermissionMaps = new HashSet<RolePermissionMap>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? IsActive { get; set; }
        public string? Code { get; set; }
        public int? SortIndex { get; set; }
        public DateTime CreateTime { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<AccountRoleMap> AccountRoleMaps { get; set; }
        public virtual ICollection<RolePermissionMap> RolePermissionMaps { get; set; }
    }
}
