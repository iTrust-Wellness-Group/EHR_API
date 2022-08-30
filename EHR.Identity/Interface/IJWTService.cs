using EHR.Identity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Identity.Interface
{
    internal interface IJWTService
    {
        public string GenerateTokens(JWTUserTypeEnum jute, Claim[] claims, DateTime now, bool isRefresh = false);

        public string ReadClaimByExp(string token);
        public DateTime ReadClaimByDtExp(string token);

        public Claim[] ReadClaims(string token);
        public (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);
    }
}
