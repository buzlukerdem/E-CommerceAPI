using E_Commerce.Application.Abstractions.Storage;
using E_Commerce.Application.Repositories.ICustomer;
using E_Commerce.Application.Repositories.IProduct;
using E_Commerce.Application.Repositories.IProductImageFile;
using E_Commerce.Application.RequestParameters;
using E_Commerce.Application.ViewModels.Products;
using E_Commerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IProductImageFileReadRepository _productImageFileReadRepository;
        private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        private readonly IStorageService _storageService;


        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IWebHostEnvironment webHostEnvironment, IProductImageFileReadRepository productImageFileReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository, IStorageService storageService)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _webHostEnvironment = webHostEnvironment;

            _productImageFileReadRepository = productImageFileReadRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _storageService = storageService;
        }

        #region dumnytest
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
        //    //Product p = await _productReadRepository.GetByIdAsync("eb79b4aa-d581-4af1-b42e-9a560f5dee20");
        //    //p.Price = 20000;
        //    //await _productWriteRepository.SaveChangesAsync();

        //    //return Ok("Başarılı");
        //    #endregion
        //    return Ok();

        //}
        #endregion


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestPagination pagination)
        {
            var totalCount = _productReadRepository.GetAll(false).Count();
            //notracking
            var products = _productReadRepository.GetAll(false).Select(p => new
            {
                p.Id,
                p.Name,
                p.Price,
                p.Stock,
                p.CreatedTime,
                p.UpdatedTime

            }).Skip(pagination.Page * pagination.Size).Take(pagination.Size);
            return Ok(new
            {
                totalCount,
                products
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            //notracking
            return Ok(_productReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            if (ModelState.IsValid)
            {

            }
            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock
            });
            await _productWriteRepository.SaveChangesAsync();
            return Ok((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Name = model.Name;
            product.Price = model.Price;
            product.Stock = model.Stock;
            await _productWriteRepository.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveChangesAsync();
            return Ok();
        }


        // Upload action
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            var datas = await _storageService.UploadAsync("resource/images", Request.Form.Files);
            await _productImageFileWriteRepository.AddRangeAsync(datas.Select(d => new ProductImageFile()
            {
                FileName = d.fileName,
                Path = d.pathOrContainerName,
                Storage = _storageService.StorageName
            }).ToList());

            await _productImageFileWriteRepository.SaveChangesAsync();

            return Ok();
        }

    }
}
