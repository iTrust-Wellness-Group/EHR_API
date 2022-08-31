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
                jwtOptions.Audience = "http://localhost:4200/";
                jwtOptions.Authority = "http://localhost:5000/";
                jwtOptions.SaveToken = true;
                jwtOptions.RequireHttpsMetadata = false;
                jwtOptions.Configuration = new OpenIdConnectConfiguration();
                jwtOptions.TokenValidationParameters = new TokenValidationParameters
                {
                //    ValidateIssuerSigningKey = true,
                //    ValidateLifetime = true,
                //    ValidateIssuer = true,
                //    ValidIssuer = "Also My Issuer",    //Missing line here
                //    ValidateAudience = true

                    ValidateIssuer = true,
                    ValidIssuer = "https://localhost:44339/",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetValue<string>("FrontendJwtTokenConfig:Secret"))),
                    ValidAudiences = new List<string> {
                        "https://localhost:7111/"
                    },
                    ValidateAudience = true,
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
