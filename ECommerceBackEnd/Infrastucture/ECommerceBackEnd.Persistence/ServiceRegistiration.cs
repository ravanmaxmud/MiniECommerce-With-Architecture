using ECommerceBackEnd.Application.Abstraction;
using ECommerceBackEnd.Persistence.Concreats;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceService(this IServiceCollection services) 
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
