using EHR.Identity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EHR.Identity.Utility.Extension
{
    public static class TokenExtension
    {
        public static String FindClaim(this Claim[] claims,JWTClaimEnum key)
        {
            String name = key.ToString();
            String value = claims.First(claim => claim.Type == name).Value;
            return value;
        }
    }
}
