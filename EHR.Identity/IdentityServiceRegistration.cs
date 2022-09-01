using EHR.Identity.Interface;
using EHR.Identity.Models;
using EHR.Identity.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddScoped<IJWTService, JWTService>();
            #endregion

            #region Auth
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwtOptions =>
            {
               
                jwtOptions.SaveToken = true;
                jwtOptions.RequireHttpsMetadata = false;
                jwtOptions.Configuration = new OpenIdConnectConfiguration();
                jwtOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetValue<string>("BackendJwtTokenConfig:Secret"))),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMilliseconds(1)
                };
            });
            services.AddAuthorization();
            var frontendJwtTokenConfig = configuration.GetSection("FrontendJwtTokenConfig").Get<FrontendJwtTokenConfig>();
            services.AddSingleton<FrontendJwtTokenConfig>(frontendJwtTokenConfig);
            var backendJwtTokenConfig = configuration.GetSection("BackendJwtTokenConfig").Get<BackendJwtTokenConfig>();
            services.AddSingleton<BackendJwtTokenConfig>(backendJwtTokenConfig);

            services.AddHttpContextAccessor();
            services.AddScoped<ClaimsPrincipal>(s => s.GetService<IHttpContextAccessor>().HttpContext.User);
            #endregion




            return services;
        }
    }
}
