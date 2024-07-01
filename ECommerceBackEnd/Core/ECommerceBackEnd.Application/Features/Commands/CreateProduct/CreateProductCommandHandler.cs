using ECommerceBackEnd.Application.Abstractions.Storage;
using ECommerceBackEnd.Application.Contracts;
using ECommerceBackEnd.Application.Repositories;
using ECommerceBackEnd.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {

        readonly IProductImageWriteRepository _productImageWriteRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly IStorageService _storageService;
        public CreateProductCommandHandler(IProductImageWriteRepository productImageWriteRepository,
            IProductWriteRepository productWriteRepository, 
            IStorageService storageService)
        {
            _productImageWriteRepository = productImageWriteRepository;
            _productWriteRepository = productWriteRepository;
            _storageService = storageService;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
         
            var product = new Product
            {
                Name = request.Name,
                Stock = request.Stock,
                Price = request.Price,
            };
            await _productWriteRepository.AddAsync(product);
            var imageNamesSystem = await _storageService.UploadRangeAsync(request.file!, UploadDirectory.Products);
            var productImgs = await _productImageWriteRepository.AddRangeAsync(imageNamesSystem.Select(imageNameSystem => new ProductImageFile()
            {

                FileName = request.file!.FirstOrDefault()!.FileName,
                Path = imageNameSystem,
                Product = product,
                Storage = _storageService.StorageName,
            }).ToList());

            await _productWriteRepository.SaveAsync();
            return new()
            {
                StatusCode = HttpStatusCode.Created,
            };
        }
    }
}
