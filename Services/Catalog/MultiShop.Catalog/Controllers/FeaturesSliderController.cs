using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatuesSliderDtos;
using MultiShop.Catalog.Services.FeaturesSLiderService;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesSliderController : ControllerBase
    {
      private readonly IFeaturesSliderService _featureSliderServices;

        public FeaturesSliderController(IFeaturesSliderService featureSliderServices)
        {
            _featureSliderServices = featureSliderServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetFeatureSliderList()
        {
            var values = await _featureSliderServices.GetAllFeatureSliderAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureSliderById(string id)
        {
            var values = await _featureSliderServices.GetByIdFeatureSliderAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeaturesSliderDto createFeaturesSliderDto)
        {
            await _featureSliderServices.CreateFeatureSliderAsync(createFeaturesSliderDto);
            return Ok("Öne çıkan Görsel Başarıla Eklendi.");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string Id)
        {
            await _featureSliderServices.DeleteFeatureSliderAsync(Id);
            return Ok("Öne çıkan Görsel  Başarıla Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeaturesSliderDto updateFeatureSliderDto)
        {
            await _featureSliderServices.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return Ok("Öne çıkan Görsel  Başarıla düzenlendi.");
        }

    }
}
