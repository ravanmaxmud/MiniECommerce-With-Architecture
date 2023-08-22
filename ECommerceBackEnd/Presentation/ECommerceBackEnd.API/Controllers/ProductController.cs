using ECommerceBackEnd.Application.Repositories;
using ECommerceBackEnd.Domain.Entities;
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
        public async Task Get()
        {
          
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) 
        {
           Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
