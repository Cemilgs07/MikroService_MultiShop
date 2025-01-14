using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var values = await _productServices.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var values = await _productServices.GetByIdProductDtoAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productServices.CreateProductAsync(createProductDto);
            return Ok("Product Başarıla Eklendi.");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct(string Id)
        {
            await _productServices.DeleteProductAsync(Id);
            return Ok("Product Başarıla Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productServices.UpdateProductAsync(updateProductDto);
            return Ok("Product Başarıla düzenlendi.");
        }

        [HttpGet("ResultProductsWithCategory")]
        public async Task<IActionResult> ResultProductsWithCategory()
        {
            var result = await _productServices.ResultProductsWithCategoriesAsync();
            return Ok(result);
        }

        [HttpGet("GetProductWithCategoryIdAsync/{Id}")]
        public async Task<IActionResult> GetProductWithCategoryIdAsync(string Id)
        {
            var result = await _productServices.GetProductWithCategoryIdAsync(Id);
            return Ok(result);
        }
    }
}
