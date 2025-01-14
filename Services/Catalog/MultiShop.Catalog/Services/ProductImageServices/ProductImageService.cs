using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ProductImageImageServices;
using MultiShop.Catalog.Setting;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageImageService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImage> _ProdcutImageCollection;

        public ProductImageService(IMapper mapper,IDataBaseSettings _dataBaseSettings)
        {
            var client = new MongoClient(_dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(_dataBaseSettings.DatabaseName);
            _ProdcutImageCollection = database.GetCollection<ProductImage>(_dataBaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(createProductImageDto);
            await _ProdcutImageCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _ProdcutImageCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _ProdcutImageCollection.Find<ProductImage>(x => true).ToListAsync();
            var resultapper = _mapper.Map<List<ResultProductImageDto>>(values);
            return resultapper;
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageDtoAsync(string id)
        {
            var values = await _ProdcutImageCollection.Find<ProductImage>(x => x.ProductImageId == id).FirstOrDefaultAsync();
            var resultmapper = _mapper.Map<GetByIdProductImageDto>(values);
            return resultmapper;
        }

        public async Task<GetByIdProductImageDto> GetByProductIdProductImageDtoAsync(string id)
        {
            var values = await _ProdcutImageCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            var result = _mapper.Map<GetByIdProductImageDto>(values);
            return result;
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(updateProductImageDto);
            await _ProdcutImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, values);
        }
    }
}
