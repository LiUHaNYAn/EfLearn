using System;

namespace middleware1.Middleware
{
    public class RequestInfo
    {
        public  string RequestUrl { get; set; }
        public  DateTime StartTime { get; set; }
        public  DateTime EndTime { get; set; }
        public  string ContentType { get; set; }
        public  string ConnectionId { get; set; }
        public string TakeTime { get; set; }
        public  string IP { get; set; }
        public  string RemotePort { get; set; }
        public override string ToString()
        {
            return $"请求id：{ConnectionId}，请求地址：{RequestUrl}，请求类型：{ContentType}；请求的开始时间：" +
                   $"{StartTime:yyyy-MM-dd HH:mm:ss.ffffff}；请求结束时间：{EndTime:yyyy-MM-dd HH:mm:ss.ffffff}，" +
                   $"请求耗费时间：{TakeTime}；请求的远程地址：{IP}，远程端口：{RemotePort}";
        }
    }
}