using ECommerceBackEnd.Application.Repositories;
using ECommerceBackEnd.Domain.Entities.Common;
using ECommerceBackEnd.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ECommerceDBContext _dbContext;

        public WriteRepository(ECommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntyr = await Table.AddAsync(model);
            return entityEntyr.State == EntityState.Added;
        }
        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Delete(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool DeleteRange(List<T> datas)
        {
             Table.RemoveRange(datas);
            return true;
        }
        public async Task<bool> DeleteAsync(string id)
        {
          T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
          return Delete(model);
        }

        public bool UpdateAsync(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State != EntityState.Modified;
        }
        public async Task<int> SaveAsync()
           => await _dbContext.SaveChangesAsync();
    }
}
