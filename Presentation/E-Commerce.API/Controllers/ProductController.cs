using E_Commerce.Application.Repositories.IProduct;
using E_Commerce.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        #region DummyTest
        //[HttpGet]
        //public async Task Get()
        //{
        //    await _productWriteRepository.AddAsync(new() { Id = Guid.NewGuid(), Name = "DummyProduct", Price = 100, Stock = 250, CreatedTime = DateTime.UtcNow });
        //    var count = await _productWriteRepository.SaveChangesAsync();

        //}
        #endregion

    }
}
