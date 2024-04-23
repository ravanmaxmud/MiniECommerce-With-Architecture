using ECommerceBackEnd.Domain.Entities;
using ECommerceBackEnd.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Persistence.Contexts
{
    public class ECommerceDBContext : DbContext
    {
        public ECommerceDBContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
               //ChangeTacker entityler uzerinde edilen deyisikleri ve ya
               //yeni elave edilen datanin yakalnmasini (tutulmasini) saglayan bir propertydir.
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ =  data.State switch
                {
                    EntityState.Added => data.Entity.CreatedAt = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedAt = DateTime.UtcNow,
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
