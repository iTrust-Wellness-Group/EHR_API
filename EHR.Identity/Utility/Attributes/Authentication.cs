using EHR.Identity.Interface;
using EHR.Identity.Models;
using EHR.Identity.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Identity.Utility.Attributes
{
    public class Authentication : AuthorizeAttribute, IAuthorizationFilter
    {
        JWTUserRolesEnum[] roles;
        public Authentication(params JWTUserRolesEnum[] roles) {
            this.roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            IJWTService service = new JWTService();

            String token = context.HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];

            var claims = service.ReadClaims(token);
            foreach (var claim in claims)
            {
                switch (claim.Type)
                {
                    case "Role":
                        break;
                }
            }

        }
    }
}
