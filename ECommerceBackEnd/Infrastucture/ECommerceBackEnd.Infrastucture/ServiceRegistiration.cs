using ECommerceBackEnd.Application.Abstractions.Storage;
using ECommerceBackEnd.Application.Services;
using ECommerceBackEnd.Infrastucture.Enums;
using ECommerceBackEnd.Infrastucture.Services;
using ECommerceBackEnd.Infrastucture.Services.Storage;
using ECommerceBackEnd.Infrastucture.Services.Storage.Local;
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
            services.AddScoped<IStorageService, StorageService>();
        }

        public static void AddStorage<T>(this IServiceCollection services) where T : class , IStorage
        {
           services.AddScoped<IStorage,T>();
        }

        public static void AddStorage<T>(this IServiceCollection services,StorageType storageType) 
        {

            switch (storageType)
            {
                case StorageType.Local:
                    services.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:

                    break;
                default:
                    services.AddScoped<IStorage, LocalStorage>();
                    break;
            }
          
        }
    }
}
