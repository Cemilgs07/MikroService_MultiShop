using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Setting;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProdcutDetailService : IProductDetailService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductDetail> _productDetail;

        public ProdcutDetailService(IMapper mapper, IDataBaseSettings _dataBaseSettings)
        {
            var client = new MongoClient(_dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(_dataBaseSettings.DatabaseName);
            _productDetail = database.GetCollection<ProductDetail>(_dataBaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var values = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetail.InsertOneAsync(values);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetail.DeleteOneAsync(x => x.ProdcutDetailId == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _productDetail.Find<ProductDetail>(x => true).ToListAsync();
            var resultapper = _mapper.Map<List<ResultProductDetailDto>>(values);
            return resultapper;
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailDtoAsync(string id)
        {
            var values = await _productDetail.Find<ProductDetail>(x => x.ProdcutDetailId == id).FirstOrDefaultAsync();
            var resultmapper = _mapper.Map<GetByIdProductDetailDto>(values);
            return resultmapper;
        }

        public async Task<GetByIdProductDetailDto> GetProductIdDetailDtoAsync(string id)
        {
            var values = await _productDetail.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            var result = _mapper.Map<GetByIdProductDetailDto>(values);
            return result;
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetail.FindOneAndReplaceAsync(x => x.ProdcutDetailId == updateProductDetailDto.ProdcutDetailId, values);
        }
    }
}
