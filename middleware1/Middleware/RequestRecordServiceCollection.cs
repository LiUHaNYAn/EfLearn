using System;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Antiforgery.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace middleware1.Middleware
{
    public static class RequestRecordServiceCollection
    {
        public static IServiceCollection AddRequestRecordService(this IServiceCollection collection,
            Action<RequestOptions> requestoptions)
        {
            /*serviceCollection.AddTransient<RequestOptions>();*/
        
            collection.AddRequestRecordService();
            collection.Configure<RequestOptions>(requestoptions);
            return collection;
        }

        public static IServiceCollection AddRequestRecordService(this IServiceCollection serviceCollection)
        { 
            serviceCollection.AddTransient<RequestRecordMiddleWare>();
            return serviceCollection;
        }
    }
}