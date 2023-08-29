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

        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
        }

        [HttpGet("GetProducts")]
        public async Task Get()
        {
            var customerId = Guid.NewGuid();
            _customerWriteRepository.AddAsync(new() { Id = customerId,Name = "REVAN"});
            _orderWriteRepository.AddAsync(new Order { Address = "Baki",CustomerId = customerId});
            _orderWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) 
        {
           Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
