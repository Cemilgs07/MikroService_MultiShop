using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageImageServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageImageService _productImageImageService;

        public ProductImageController(IProductImageImageService productImageImageService)
        {
            _productImageImageService = productImageImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductImageList()
        {
            var values = await _productImageImageService.GetAllProductImageAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var values = await _productImageImageService.GetByIdProductImageDtoAsync(id);
            return Ok(values);
        }
        [HttpGet("ProductImageDetails/{id}")]
        public async Task<IActionResult> GetProductProductIdImage(string id)
        {
            var values = await _productImageImageService.GetByProductIdProductImageDtoAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("ProductImage Başarıla Eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageImageService.DeleteProductImageAsync(id);
            return Ok("Category Başarıla Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Category Başarıla düzenlendi.");
        }
    }
}
