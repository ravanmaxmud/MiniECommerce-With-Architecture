using ECommerceBackEnd.Application.Abstraction;
using ECommerceBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Persistence.Concreats
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
            => new() 
            {
               new(){ Id = Guid.NewGuid(), Name="Product1", Price=100, Stock=5 },
               new(){ Id = Guid.NewGuid(), Name="Product2", Price=300, Stock=5 },
               new(){ Id = Guid.NewGuid(), Name="Product3", Price=400, Stock=5 },
               new(){ Id = Guid.NewGuid(), Name="Product4", Price=500, Stock=5 },
               new(){ Id = Guid.NewGuid(), Name="Product5", Price=600, Stock=5 },
            };
    }
}
