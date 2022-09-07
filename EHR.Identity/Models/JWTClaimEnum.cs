using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Identity.Models
{
    public enum JWTClaimEnum
    {
        UserId,
        Name,
        Email,
        Mobile,
        Role,
        RoleId
    }
}
