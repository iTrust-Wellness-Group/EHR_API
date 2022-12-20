using EHR.Identity.Interface;
using EHR.Identity.Models;
using EHR.Identity.Service;
using EHR.Identity.Utility.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Identity.Utility.Attributes
{
    public class AuthenticationService : AuthorizeAttribute,IAuthorizationFilter
    {
        public AuthenticationService()
        {
        }
     
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            IJWTService service = new JWTService();
            String ControllerName = context.HttpContext.Request.RouteValues.Values.ToList()[1].ToString();
            if(!ControllerName.Equals("Identity"))
            {
                String token = context.HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
                String RoleId = service.ReadClaims(token).FindClaim(JWTClaimEnum.RoleId);
                String ServiceName = service.ReadClaims(token).FindClaim(JWTClaimEnum.Name);

                if (RoleId.Equals("Service"))
                {
                    if (!ServiceName.Equals(ControllerName))
                    {
                        context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                    }

                }
            }
            

        }

   
    }
}
