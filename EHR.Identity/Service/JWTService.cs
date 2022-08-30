using EHR.Identity.Interface;
using EHR.Identity.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Identity.Service
{
    internal class JWTService : IJWTService
    {
        private readonly FrontendJwtTokenConfig _frontendJwtTokenConfig;
        private readonly BackendJwtTokenConfig _backendJwtTokenConfig;
        private readonly byte[] _backendSecret;
        private readonly byte[] _frontendSecret;

        public JWTService(FrontendJwtTokenConfig frontendJwtTokenConfig, BackendJwtTokenConfig backendJwtTokenConfig)
        {
            _frontendJwtTokenConfig = frontendJwtTokenConfig;
            _frontendSecret = Encoding.ASCII.GetBytes(_frontendJwtTokenConfig.Secret);

            _backendJwtTokenConfig = backendJwtTokenConfig;
            _backendSecret = Encoding.ASCII.GetBytes(_backendJwtTokenConfig.Secret);
        }

        public string ReadClaimByExp(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var s = jwtSecurityToken.Claims.First(claim => claim.Type == "exp").Value;
            var longresult = Convert.ToInt64(s);
            var result = DateTimeOffset.FromUnixTimeSeconds(longresult).AddHours(8).ToString("yyyy/MM/dd HH:mm:ss");
            return result;
        }
        public DateTime ReadClaimByDtExp(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var s = jwtSecurityToken.Claims.First(claim => claim.Type == "exp").Value;
            var longresult = Convert.ToInt64(s);
            var result = DateTimeOffset.FromUnixTimeSeconds(longresult).AddHours(8).DateTime;
            return result;
        }

        public Claim[] ReadClaims(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var result = jwtSecurityToken.Claims.ToArray();
            return result;
        }


        public (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new SecurityTokenException("Invalid token");
            }

            var principal = new JwtSecurityTokenHandler()
                .ValidateToken(token,
                    new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = _frontendJwtTokenConfig.Issuer,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(_frontendSecret),// new SymmetricSecurityKey(_frontendSecret),
                    ValidAudience = _frontendJwtTokenConfig.Audience,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    },
                    out var validatedToken);
            return (principal, validatedToken as JwtSecurityToken);
        }

        public string GenerateTokens(JWTUserTypeEnum jwtType, Claim[] claims, DateTime now, bool isRefresh = false)
        {
            JwtSecurityToken jwtToken;
            switch (jwtType)
            {
                case JWTUserTypeEnum.Frontend:
                    jwtToken = GenerateFrontendToken(claims, now, isRefresh);
                    break;
                case JWTUserTypeEnum.Backend:
                    jwtToken = GenerateBackendToken(claims, now);
                    break;
                default:
                    throw new NotImplementedException("Enum no incompatible.");
            }
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return accessToken;
        }
        private JwtSecurityToken GenerateFrontendToken(Claim[] claims, DateTime now, bool isRefresh = false)
        {
            int expirationMinute = 1440;
            if (isRefresh)
            {
                expirationMinute = 1440;
            }
            var jwtToken = new JwtSecurityToken(
                _frontendJwtTokenConfig.Issuer,
                _frontendJwtTokenConfig.Audience ?? string.Empty,
                claims,
                expires: now.AddMinutes(expirationMinute),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_frontendSecret), SecurityAlgorithms.HmacSha256Signature));
            return jwtToken;

        }
        private JwtSecurityToken GenerateBackendToken(Claim[] claims, DateTime now)
        {
            int expirationMinute = 1440;

            var jwtToken = new JwtSecurityToken(
                _backendJwtTokenConfig.Issuer,
                _backendJwtTokenConfig.Audience ?? string.Empty,
                claims,
                expires: now.AddMinutes(expirationMinute),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_backendSecret), SecurityAlgorithms.HmacSha256Signature));
            return jwtToken;
        }

    }
}
