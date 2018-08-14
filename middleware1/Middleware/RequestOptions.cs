using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace middleware1.Middleware
{
    public class RequestOptions
    {
        
       /// <summary>
       /// 是否启用IP黑名单
       /// </summary>
        public  bool UseBlackIP { get; set; }
        /// <summary>
        /// ip黑名单列表
        /// </summary>
        public  List<string> BlackList { get; set; }
        /// <summary>
        /// 每个ip每分钟最大的访问数
        /// </summary>
        public  int MaxNumPerMI { get; set; }
        public  string RedirectUrl { get; set; }
        public  DbContext DbContext { get; set; }
    }
 
}