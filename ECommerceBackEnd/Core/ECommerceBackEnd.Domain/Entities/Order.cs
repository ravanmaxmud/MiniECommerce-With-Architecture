using ECommerceBackEnd.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Address { get; set; }
        public ICollection<Product> Products { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
