using ECommerceBackEnd.Application.Repositories;
using ECommerceBackEnd.Application.Repositories.Invoice;
using ECommerceBackEnd.Persistence.Contexts;
using ECommerceBackEnd.Persistence.Repositories;
using ECommerceBackEnd.Persistence.Repositories.File;
using ECommerceBackEnd.Persistence.Repositories.Invoice;
using ECommerceBackEnd.Persistence.Repositories.ProductImage;
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


            services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFIleWriteRepository, FileWriteRepository>();

            services.AddScoped<IProductImageReadRepository,ProductImageReadRepository>();
            services.AddScoped<IProductImageWriteRepository,ProductImageWriteRepository>();

            services.AddScoped<IInvoiceReadRepository,InvoiceReadRepository>();
            services.AddScoped<IInvoiceWriteRepository,InvoiceWriteRepository>();
        }
    }
}
