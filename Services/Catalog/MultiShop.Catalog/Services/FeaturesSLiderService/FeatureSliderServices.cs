using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatuesSliderDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Setting;

namespace MultiShop.Catalog.Services.FeaturesSLiderService
{
    public class FeatureSliderServices : IFeaturesSliderService
    {
        private readonly IMongoCollection<FeaturesSlider> _featuescollection;
        private readonly IMapper _mapper;
        public FeatureSliderServices(IMapper mapper, IDataBaseSettings _dataBaseSettings)
        {
            var client = new MongoClient(_dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(_dataBaseSettings.DatabaseName);
            _featuescollection = database.GetCollection<FeaturesSlider>(_dataBaseSettings.FeaturesSliderNameCollectionName);
            _mapper = mapper;
        }
        public async Task CreateFeatureSliderAsync(CreateFeaturesSliderDto createFeaturesSliderDto)
        {
            var result = _mapper.Map<FeaturesSlider>(createFeaturesSliderDto);
            await _featuescollection.InsertOneAsync(result);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featuescollection.DeleteOneAsync(x=>x.FeaturesSliderId==id);
        }

        public async Task FeaturesChangeToStatusTrue(string id)
        {
             var values= await _featuescollection.FindAsync(x=>x.FeaturesSliderId==id);
                //values.s
        }

        public Task FeaturesChangeToStatusFalse(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeaturesSliderDto>> GetAllFeatureSliderAsync()
        {
            var values = await _featuescollection.Find(x => true).ToListAsync();
             return _mapper.Map<List<ResultFeaturesSliderDto>>(values);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeaturesSliderDto updateFeatuesSliderDto)
        {
            var values = _mapper.Map<FeaturesSlider>(updateFeatuesSliderDto);
            var result = await _featuescollection.FindOneAndReplaceAsync<FeaturesSlider>(x => x.FeaturesSliderId == updateFeatuesSliderDto.FeaturesSliderId, values, null);
        }

        public async Task<GetByIdFeaturesSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var values = await _featuescollection.Find<FeaturesSlider>(x => x.FeaturesSliderId == id).FirstOrDefaultAsync();
            var resultmapper = _mapper.Map<GetByIdFeaturesSliderDto>(values);
            return resultmapper;
        }
    }
}
