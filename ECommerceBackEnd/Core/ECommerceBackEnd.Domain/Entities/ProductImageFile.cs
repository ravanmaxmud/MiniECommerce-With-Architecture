using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Domain.Entities
{
    public class ProductImageFile : EntityFile
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
