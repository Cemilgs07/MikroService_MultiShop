using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.SpecialOffterDtos;

namespace MultiShop.Catalog.Services.SpecialOftterService
{
    public interface ISpecialOffterService
    {
        Task<List<ResultSpecialOffterDto>> GetAllSpecialOffterAsync();
        Task CreateSpecialOffterAsync(CreateSpecialOffterDto createProductDto);
        Task UpdateSpecialOffterAsync(UpdateSpecialOffterDto updateProductDto);
        Task DeleteSpecialOffterAsync(string id);
        Task<GetByIDSpecialOffterDto> GetByIdSpecialOffterAsync(string id);
    }
}
