using ECommerceBackEnd.Application.Repositories;
using ECommerceBackEnd.Domain.Entities;
using ECommerceBackEnd.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Persistence.Repositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(ECommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
