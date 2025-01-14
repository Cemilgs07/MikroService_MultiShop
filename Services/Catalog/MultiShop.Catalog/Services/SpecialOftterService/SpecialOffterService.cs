using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.SpecialOffterDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Setting;
using static MongoDB.Driver.WriteConcern;

namespace MultiShop.Catalog.Services.SpecialOftterService
{
    public class SpecialOffterService : ISpecialOffterService
    {
        private readonly IMongoCollection<SpecialOffter> _specialCollection;
        private readonly IMapper _mapper;

        public SpecialOffterService(IDataBaseSettings _dataBaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(_dataBaseSettings.DatabaseName);
            _specialCollection = database.GetCollection<SpecialOffter>(_dataBaseSettings.SpecialOftterCollectionName);
            _mapper = mapper;
        }
        public async Task CreateSpecialOffterAsync(CreateSpecialOffterDto createProductDto)
        {
            
            var values = _mapper.Map<SpecialOffter>(createProductDto);
            await _specialCollection.InsertOneAsync(values);
        }

        public async Task DeleteSpecialOffterAsync(string id)
        {
            await _specialCollection.DeleteOneAsync(x => x.SpecialOffterId == id);

        }

        public async Task<List<ResultSpecialOffterDto>> GetAllSpecialOffterAsync()
        {
            var values = await _specialCollection.Find<SpecialOffter>(x => true).ToListAsync();
            var resultapper = _mapper.Map<List<ResultSpecialOffterDto>>(values);
            return resultapper;
        }

        public async Task<GetByIDSpecialOffterDto> GetByIdSpecialOffterAsync(string id)
        {
            var values = await _specialCollection.Find<SpecialOffter>(x => x.SpecialOffterId == id).FirstOrDefaultAsync();
            var resultmapper = _mapper.Map<GetByIDSpecialOffterDto>(values);
            return resultmapper;
        }

        public async Task UpdateSpecialOffterAsync(UpdateSpecialOffterDto updateProductDto)
        {

            var values = _mapper.Map<SpecialOffter>(updateProductDto);
            await _specialCollection.FindOneAndReplaceAsync(x => x.SpecialOffterId == updateProductDto.SpecialOffterId, values);
        }
    }
}
