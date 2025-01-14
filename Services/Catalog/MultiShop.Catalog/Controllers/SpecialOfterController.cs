using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOffterDtos;
using MultiShop.Catalog.Services.SpecialOftterService;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOfterController : Controller
    {
        private readonly ISpecialOffterService _specialOffterService;

        public SpecialOfterController(ISpecialOffterService specialOffterService)
        {
            _specialOffterService = specialOffterService;
        }
        [HttpGet]
        public async Task<IActionResult> GetSpecialOffterList()
        {
            var values = await _specialOffterService.GetAllSpecialOffterAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialOffterById(string id)
        {
            var values = await _specialOffterService.GetByIdSpecialOffterAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffter(CreateSpecialOffterDto createSpecialOffterDto)
        {
            await _specialOffterService.CreateSpecialOffterAsync(createSpecialOffterDto);
            return Ok("SpecialOffter Başarıla Eklendi.");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteSpecialOffter(string Id)
        {
            await _specialOffterService.DeleteSpecialOffterAsync(Id);
            return Ok("SpecialOffter Başarıla Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffter(UpdateSpecialOffterDto updateSpecialOffterDto)
        {
            await _specialOffterService.UpdateSpecialOffterAsync(updateSpecialOffterDto);
            return Ok("SpecialOffter Başarıla düzenlendi.");
        }

       
    }

}

