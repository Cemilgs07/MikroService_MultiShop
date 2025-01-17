using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.AboutDto;
using MultiShop.Catalog.Services.AboutService;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutServices;

        public AboutController(IAboutService aboutServices)
        {
            _aboutServices = aboutServices;
        }

        [HttpGet("GetAbout")]
        public async Task<IActionResult> GetAbout()
        {
            var values = await _aboutServices.AboutAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createProductDto)
        {
            await _aboutServices.CreateAboutAsync(createProductDto);
            return Ok("About Başarıla Eklendi.");
        }


    }
}
