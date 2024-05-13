﻿using ECommerceBackEnd.Application.Repositories;
using ECommerceBackEnd.Domain.Entities;
using ECommerceBackEnd.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Persistence.Repositories.ProductImage
{
    public class ProductImageWriteRepository : WriteRepository<ProductImageFile>, IProductImageWriteRepository
    {
        public ProductImageWriteRepository(ECommerceDBContext dbContext) : base(dbContext)
        {
        }
    }
}
