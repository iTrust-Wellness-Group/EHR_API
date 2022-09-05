using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;

namespace EHR.API.MiddleWare
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            var queryPath = context.Request.Path.Value;
            if (!queryPath.Contains("swagger"))
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
                    Console.WriteLine(log);
                }

                // set HTTP Request Stream position = 0 , let can be read again
                context.Request.Body.Position = 0;

                await _next.Invoke(context);

            }
            else
            {
                await _next(context);
            }


        }
        }
}
