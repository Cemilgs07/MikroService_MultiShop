using MultiShop.Catalog.Dtos.FeatuesSliderDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.FeaturesSLiderService
{
    public interface IFeaturesSliderService 
    {
        Task<List<ResultFeaturesSliderDto>> GetAllFeatureSliderAsync();
        Task CreateFeatureSliderAsync(CreateFeaturesSliderDto createFeaturesSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeaturesSliderDto updateFeatuesSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task FeaturesChangeToStatusTrue(string id);
        Task FeaturesChangeToStatusFalse(string id);
        Task<GetByIdFeaturesSliderDto> GetByIdFeatureSliderAsync(string id);

    }
}
