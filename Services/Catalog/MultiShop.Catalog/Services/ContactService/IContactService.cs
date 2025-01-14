using MultiShop.Catalog.Dtos.ContactDto;

namespace MultiShop.Catalog.Services.ContactService
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task DeleteContactAsync(string id);
        Task<GetByIdContactDto> GetByIdContactDtoAsync(string id);
    }
}
