using EHR.Database.Context;
using EHR.Database.Entities;
using EHR.Identity.Interface;
using EHR.Identity.Models;
using EHR.Identity.Service;
using EHR.Identity.Utility.Extension;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;

namespace EHR.API.MiddleWare
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context,IJWTService service,DatabaseContext dbcontext)
        {

           

                // makesure HTTP Request can be read more
                context.Request.EnableBuffering();
                // read HTTP Request Body 
                // set  leaveOpen = true. When StreamReader is close,HTTP Request Stream won't close together
                using (var bodyReader = new StreamReader(stream: context.Request.Body,
                                                          encoding: Encoding.UTF8,
                                                          detectEncodingFromByteOrderMarks: false,
                                                          bufferSize: 1024,
                                                          leaveOpen: true))
                {
                    var body = await bodyReader.ReadToEndAsync();
                    var log = $"{context.Request.Path}, {context.Request.Method}, {body}";
                    
                    String token = context.Request.Headers.Authorization.ToString();
                    if (!String.IsNullOrEmpty(token))
                    {
                        try
                        {
                            Claim[] claims = service.ReadClaims(token);
                            AccessLog accessLog = new AccessLog();
                            string userId = claims.FindClaim(JWTClaimEnum.UserId);
                            accessLog.Id = Guid.NewGuid();
                            accessLog.ModifyUserId = Guid.Parse(userId);
                            accessLog.ControllerName = context.Request.RouteValues.Values.ToList()[1].ToString();
                            accessLog.ActionName = context.Request.RouteValues.Values.ToList()[0].ToString();
                            accessLog.Action = context.Request.Method;
                            accessLog.CreateTime = DateTime.UtcNow;
                            if (context.Request.Method.Equals("GET"))
                            {
                                if (context.Request.QueryString.HasValue)
                                    accessLog.OrignData = context.Request.QueryString.Value;
                            }
                            else
                            {
                                accessLog.OrignData = body;
                            }
                            dbcontext.AccessLogs.Add(accessLog);
                            dbcontext.SaveChanges();
                        }
                        catch(Exception ex)
                        {

                        }
                        
                    }

                    Console.WriteLine(log);
                }

                // set HTTP Request Stream position = 0 , let can be read again
                context.Request.Body.Position = 0;
               
                await _next.Invoke(context);
            }
        

        }
    }
}
