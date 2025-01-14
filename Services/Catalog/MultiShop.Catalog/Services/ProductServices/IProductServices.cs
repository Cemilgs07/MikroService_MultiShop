using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductServices
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductDtoAsync(string id);

        Task<List<ResultProductsWithCategory>> ResultProductsWithCategoriesAsync();
        Task<List<ResultProductsWithCategory>> GetProductWithCategoryIdAsync(string categoryId);
    }
}
