using ECommerceBackEnd.Application.Abstractions.Storage;
using ECommerceBackEnd.Application.Contracts;
using ECommerceBackEnd.Application.Repositories;
using ECommerceBackEnd.Application.Services;
using ECommerceBackEnd.Application.ViewModels.Product;
using ECommerceBackEnd.Application.ViewModels.Products;
using ECommerceBackEnd.Domain.Entities;
using ECommerceBackEnd.Infrastucture.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Net;

namespace ECommerceBackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
     
        readonly IFileReadRepository _fileReadRepository;
        readonly IFIleWriteRepository _fIleWriteRepository;
        readonly IProductImageReadRepository _productImageReadRepository;
        readonly IProductImageWriteRepository _productImageWriteRepository;

        readonly IStorageService _storageService;

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IFileReadRepository fileReadRepository, IFIleWriteRepository fIleWriteRepository, IProductImageReadRepository productImageReadRepository, IProductImageWriteRepository productImageWriteRepository, IStorageService storageService)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;

            _fileReadRepository = fileReadRepository;
            _fIleWriteRepository = fIleWriteRepository;
            _productImageReadRepository = productImageReadRepository;
            _productImageWriteRepository = productImageWriteRepository;
            _storageService = storageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_productReadRepository.GetAll(false));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]ProductAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = new Product
            {
                Name = model.Name,
                Stock = model.Stock,
                Price = model.Price,               
            };
            await _productWriteRepository.AddAsync(product);
            var imageNamesSystem = await _storageService.UploadRangeAsync(model.file!, UploadDirectory.Products);
            var productImgs = await _productImageWriteRepository.AddRangeAsync(imageNamesSystem.Select(imageNameSystem => new ProductImageFile()
            {

                FileName = model.file!.FirstOrDefault()!.FileName,
                Path = imageNameSystem,
                Product = product,
                Storage = _storageService.StorageName,
            }).ToList());

            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductsUpdateViewModel model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Name = model.Name;
            product.Price = model.Price;

            await _productWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.DeleteAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPost("[action]")]  
        public async Task<IActionResult> Upload(IFormFile file) 
        {
           var imageNameSystem =  await _storageService.UploadAsync(file, UploadDirectory.Products);
            //_productImageWriteRepository.AddRangeAsync();

           return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> RemoveFile(string fileName)
        {
            await _storageService.DeleteAsync(fileName, UploadDirectory.Products);
            return Ok();
        }

    }
}
