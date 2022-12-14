using System;
using System.Collections.Generic;

namespace EHR.Database.Entities
{
    public partial class Permission
    {
        public Permission()
        {
            AccountPermissionMaps = new HashSet<AccountPermissionMap>();
            RolePermissionMaps = new HashSet<RolePermissionMap>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Type { get; set; }
        public string? Code { get; set; }
        public Guid? PageId { get; set; }
        public string? Note { get; set; }
        public int? SortIndex { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreateTime { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Page? Page { get; set; }
        public virtual ICollection<AccountPermissionMap> AccountPermissionMaps { get; set; }
        public virtual ICollection<RolePermissionMap> RolePermissionMaps { get; set; }
    }
}
