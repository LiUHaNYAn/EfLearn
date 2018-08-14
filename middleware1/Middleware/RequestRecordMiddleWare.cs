using System;
using System.Linq;
using System.Text;
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
            var addr = context.Connection.RemoteIpAddress.ToString();
            var ip = addr == "::1" ? "localhost" : addr;
            if (Options != null)
            {
                if (Options.UseBlackIP)
                {
                    if (Options.BlackList.Any(p => p == ip))
                    {
                        _logger.LogWarning(SysEventId.BlackVisited,"黑名单用户访问：{0}",ip);
                        if (!string.IsNullOrEmpty(Options.RedirectUrl))
                        {
                            context.Response.Redirect(Options.RedirectUrl);
                            _logger.LogInformation(SysEventId.BlackVisited,"黑名单用户跳转地址：{url}",Options.RedirectUrl);
                        }
                        else
                        {
                            context.Response.ContentType = "text/html;charset=utf-8";
                            await context.Response.WriteAsync("该IP禁止访问，请联系管理员", Encoding.UTF8);
                        } 
                        return;
                    }
                }
            }
            var request = context.Request;
            var connectionid = Guid.NewGuid().ToString();
            var requestInfo = new RequestInfo
            {
                RequestUrl = context.Request.GetDisplayUrl(),
                ConnectionId = connectionid,
                IP = addr,
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