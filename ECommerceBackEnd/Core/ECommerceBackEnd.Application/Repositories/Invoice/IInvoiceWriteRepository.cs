using ECommerceBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Application.Repositories.Invoice
{
    public interface IInvoiceWriteRepository :IWriteRepository<InvoiceFile>
    {
    }
}
