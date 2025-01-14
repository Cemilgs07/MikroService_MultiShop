using MultiShop.Catalog.Dtos.AboutDto;

namespace MultiShop.Catalog.Services.AboutService
{
    public interface IAboutService
    {
        Task CreateAboutAsync(CreateAboutDto createAboutDto);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task<UpdateAboutDto> AboutAsync();
    }
}
