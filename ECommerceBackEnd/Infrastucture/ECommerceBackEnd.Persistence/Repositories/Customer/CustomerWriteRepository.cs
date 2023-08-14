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
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(ECommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
