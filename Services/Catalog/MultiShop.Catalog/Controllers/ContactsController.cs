using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ContactDto;
using MultiShop.Catalog.Services.ContactService;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        public readonly IContactService _ContactServices;

        public ContactsController(IContactService ContactServices)
        {
            _ContactServices = ContactServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetContactList()
        {
            var values = await _ContactServices.GetAllContactAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(string id)
        {
            var values = await _ContactServices.GetByIdContactDtoAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _ContactServices.CreateContactAsync(createContactDto);
            return Ok("Contact Başarıla Eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContact(string id)
        {
            await _ContactServices.DeleteContactAsync(id);
            return Ok("Contact Başarıla Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            await _ContactServices.UpdateContactAsync(updateContactDto);
            return Ok("Contact Başarıla düzenlendi.");
        }
    }
}
