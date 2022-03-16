using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrueLayer.Application;
using Microsoft.Extensions.DependencyInjection;

namespace TrueLayer
{
    public static class ServicesConfiguration
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddApplicationCore();
        }
    }
}
