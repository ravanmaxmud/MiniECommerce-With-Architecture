using ECommerceBackEnd.Application.Repositories;
using ECommerceBackEnd.Domain.Entities.Common;
using ECommerceBackEnd.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ECommerceDBContext _dbContext;

        public ReadRepository(ECommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public IQueryable<T> GetAll()
           => Table;

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
           => Table.Where(method);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
           => await Table.FirstOrDefaultAsync(method);

        public async Task<T> GetByIdAsync(string id)
           //=> await Table.FirstOrDefaultAsync(data => data.Id ==Guid.Parse(id));
           => await Table.FindAsync(Guid.Parse(id));
    }

}
