using EHR.Shared.Utils.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Shared
{
    public static class ShareServiceRegistration
    {
        public static IServiceCollection AddShareServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpRequest, HttpRequest>();
            return services;
        }
    }
}
