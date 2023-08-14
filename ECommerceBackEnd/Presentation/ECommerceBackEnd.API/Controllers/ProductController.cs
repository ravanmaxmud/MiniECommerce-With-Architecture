using ECommerceBackEnd.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceBackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet("GetProducts")]
        public async void Get()
        {
            await _productWriteRepository.AddRangeAsync(new() 
            {
               new() { Id = Guid.NewGuid(), Name = "product 1", Price= 100,CreatedAt=DateTime.UtcNow, Stock=10 },
               new() { Id = Guid.NewGuid(), Name = "product 2", Price= 100,CreatedAt=DateTime.UtcNow, Stock=20 },
               new() { Id = Guid.NewGuid(), Name = "product 3", Price= 100,CreatedAt=DateTime.UtcNow, Stock=30 }

            });
             await _productWriteRepository.SaveAsync();
        }
    }
}
