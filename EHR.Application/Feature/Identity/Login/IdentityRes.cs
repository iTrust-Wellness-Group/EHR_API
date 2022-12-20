using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Identity.Login
{
    public class IdentityRes
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
