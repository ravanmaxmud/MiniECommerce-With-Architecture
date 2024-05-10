using ECommerceBackEnd.Application.Services;
using ECommerceBackEnd.Infrastucture.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Infrastucture
{
    public static class ServiceRegistiration
    {
        public static void AddInfrastuructureServices(this IServiceCollection services) 
        {
            services.AddScoped<IFileService,FileService>();
        }
    }
}
