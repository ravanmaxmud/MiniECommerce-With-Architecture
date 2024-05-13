using ECommerceBackEnd.Application.Repositories.Invoice;
using ECommerceBackEnd.Domain.Entities;
using ECommerceBackEnd.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Persistence.Repositories.Invoice
{
    public class InvoiceWriteRepository : WriteRepository<InvoiceFile>, IInvoiceWriteRepository
    {
        public InvoiceWriteRepository(ECommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
