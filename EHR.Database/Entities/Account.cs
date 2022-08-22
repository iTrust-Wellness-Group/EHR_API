using System;
using System.Collections.Generic;

namespace EHR.Database.Entities
{
    public partial class Account
    {
        public Account()
        {
            AccountPermissionMaps = new HashSet<AccountPermissionMap>();
            AccountProfiles = new HashSet<AccountProfile>();
            AccountRoleMaps = new HashSet<AccountRoleMap>();
        }

        public Guid Id { get; set; }
        public string? StaffAccount { get; set; }
        public string? Password { get; set; }
        public DateTime? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }
        public string? ActiveToken { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateTime { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<AccountPermissionMap> AccountPermissionMaps { get; set; }
        public virtual ICollection<AccountProfile> AccountProfiles { get; set; }
        public virtual ICollection<AccountRoleMap> AccountRoleMaps { get; set; }
    }
}
