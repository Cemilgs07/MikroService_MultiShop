using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ContactDto;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Setting;

namespace MultiShop.Catalog.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _ContactCollection;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDataBaseSettings _dataBaseSettings)
        {
            var client = new MongoClient(_dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(_dataBaseSettings.DatabaseName);
            _ContactCollection = database.GetCollection<Contact>(_dataBaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            try
            {
                var values = _mapper.Map<Contact>(createContactDto);
                await _ContactCollection.InsertOneAsync(values);
            }
            catch (Exception e)
            {
                string message = e.Message;
                throw;
            }
          
        }

        public async Task DeleteContactAsync(string id)
        {
            await _ContactCollection.DeleteOneAsync(x => x.ContactId == id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var values = await _ContactCollection.Find(x => true).ToListAsync();
            var resultmapper = _mapper.Map<List<ResultContactDto>>(values);
            return resultmapper;
        }

        public async Task<GetByIdContactDto> GetByIdContactDtoAsync(string id)
        {
            var values = await _ContactCollection.Find<Contact>(x => x.ContactId == id).FirstOrDefaultAsync();
            var ıdmapper = _mapper.Map<GetByIdContactDto>(values);
            return ıdmapper;
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var values = _mapper.Map<Contact>(updateContactDto);
            await _ContactCollection.FindOneAndReplaceAsync(c => c.ContactId == updateContactDto.ContactId, values);
        }
    }
}
