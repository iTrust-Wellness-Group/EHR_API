using EHR.Context.CRM;
using EHR.Context.Drchrono;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Context
{
    public static class ContextServiceRegistration
    {
        public static IServiceCollection AddContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DrchronoContext>();
            services.AddScoped<CRMContext>();

            return services;
        }
    }
}
