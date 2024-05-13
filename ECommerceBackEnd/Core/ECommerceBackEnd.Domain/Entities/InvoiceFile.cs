using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Domain.Entities
{
    public class InvoiceFile : EntityFile
    {
        public decimal Price { get; set; }
    }
}
