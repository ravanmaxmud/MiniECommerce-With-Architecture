using ECommerceBackEnd.Application.Abstraction;
using ECommerceBackEnd.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceService(this IServiceCollection services) 
        {
            services.AddDbContext<ECommerceDBContext>(options => 
            options.UseNpgsql(Configurations.ConnectionString));
        }
    }
}
