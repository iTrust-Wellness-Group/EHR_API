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

            //var queryPath = context.Request.Path.Value;
            //if(!queryPath.Contains("swagger"))
            //{

            //    // 確保 HTTP Request 可以多次讀取
            //    context.Request.EnableBuffering();

            //    // 讀取 HTTP Request Body 內容
            //    // 注意！要設定 leaveOpen 屬性為 true 使 StreamReader 關閉時，HTTP Request 的 Stream 不會跟著關閉
            //    using (var bodyReader = new StreamReader(stream: context.Request.Body,
            //                                              encoding: Encoding.UTF8,
            //                                              detectEncodingFromByteOrderMarks: false,
            //                                              bufferSize: 1024,
            //                                              leaveOpen: true))
            //    {
            //        var body = await bodyReader.ReadToEndAsync();
            //        var log = $"{context.Request.Path}, {context.Request.Method}, {body}";
            //        Console.WriteLine(log);
            //    }

            //    // 將 HTTP Request 的 Stream 起始位置歸零
            //    context.Request.Body.Position = 0;

            await _next.Invoke(context);

            //}
            //else
            //{
            //    await _next(context);
            //}


        }
    }
}
