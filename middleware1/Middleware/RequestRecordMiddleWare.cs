using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace middleware1.Middleware
{
    public class RequestRecordMiddleWare : IMiddleware
    {
        private ILogger<RequestRecordMiddleWare> _logger;
        
        public RequestOptions Options { get; set; }

        public RequestRecordMiddleWare(ILogger<RequestRecordMiddleWare> logger, IOptions<RequestOptions> _options)
        {
            this._logger = logger;
            this.Options = _options.Value;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            
            Console.WriteLine(this.Options);
            var addr = context.Connection.RemoteIpAddress.ToString();
            var connectionid = Guid.NewGuid().ToString();
            var requestInfo = new RequestInfo
            {
                RequestUrl = context.Request.GetDisplayUrl(),
                ConnectionId = connectionid,
                IP = addr == "::1" ? "localhost" : addr,
                RemotePort = context.Connection.RemotePort.ToString(),
                StartTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff"))
            };
            context.Connection.Id = connectionid;
            await next(context);
            requestInfo.EndTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff"));
            requestInfo.ContentType = context.Response.ContentType;
            var ts = requestInfo.EndTime - requestInfo.StartTime;
            var milliseconds = ts.TotalMilliseconds;
            if (milliseconds < 1000)
            {
                requestInfo.TakeTime = milliseconds + "毫秒";
            }
            else if (milliseconds >= 1000)
            {
                requestInfo.TakeTime = milliseconds / 1000.00 + "秒";
            }

            _logger.LogInformation("请求结果:{0}", requestInfo);
            /*Console.WriteLine(JsonConvert.SerializeObject(requestInfo));*/
        }
    }

    public static class RequestRecordMiddleWareExtesnion
    {
      
        public static IApplicationBuilder UseRequestRecordMiddleWare(this IApplicationBuilder builder)
        {
            /*return builder.UseMiddleware<RequestRecordMiddleWare>();*/
            return builder.UseMiddleware<RequestRecordMiddleWare>();
        }
    }
}