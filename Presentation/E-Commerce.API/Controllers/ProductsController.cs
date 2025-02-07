using E_Commerce.Application.Repositories.ICustomer;
using E_Commerce.Application.Repositories.IProduct;
using E_Commerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        #region DummyTest
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    #region Dummys
        //    //await _productWriteRepository.AddAsync(new() { Id = Guid.NewGuid(), Name = "DummyProduct2", Price = 100, Stock = 250, CreatedTime = DateTime.UtcNow });
        //    //await _customerWriteRepository.AddAsync(new() { Id = Guid.NewGuid(), Name = "Dummy" });

        //    //#region WithTracking
        //    //Product p = await _productReadRepository.GetByIdAsync("7a809bcb-3eaf-49a5-bdd9-4b0c6afe4453");
        //    //p.Price = 10000;
        //    //await _productWriteRepository.SaveChangesAsync();
        //    #endregion
        //    #region  WithNoTracking
        //    //WithNoTracking, isTracking=false
        //    //Product p = await _productReadRepository.GetByIdAsync("64927619-74a3-43a6-a190-34d0fb68d95b", false);
        //    //p.Price = 50500;
        //    //await _productWriteRepository.SaveChangesAsync();
        //    #endregion
        //    return Ok("Başarılı");


        //}
        #endregion

        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
