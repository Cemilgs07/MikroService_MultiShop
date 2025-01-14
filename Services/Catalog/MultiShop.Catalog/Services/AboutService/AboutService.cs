using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.AboutDto;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Setting;

namespace MultiShop.Catalog.Services.AboutService
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;
        private readonly IMapper _mapper;

        public AboutService(IMapper mapper, IDataBaseSettings _dataBaseSettings)
        {
            var client = new MongoClient(_dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(_dataBaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(_dataBaseSettings.AboutCollectionName);
            _mapper = mapper;
            _mapper = mapper;
        }

        public async Task<UpdateAboutDto> AboutAsync()
        {
            var values = await _aboutCollection.Find(x => true).FirstOrDefaultAsync();
            var result = _mapper.Map<UpdateAboutDto>(values);
            return result;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var values = _mapper.Map<About>(createAboutDto);
            await _aboutCollection.InsertOneAsync(values);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var values = _mapper.Map<About>(updateAboutDto);
            await _aboutCollection.FindOneAndReplaceAsync(c => c.AboutId == updateAboutDto.AboutId, values);
        }
    }
}
