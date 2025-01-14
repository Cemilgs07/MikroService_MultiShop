using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Setting;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductServices : IProductServices
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Category> _categoriesCollection;

        public ProductServices(IMapper mapper, IDataBaseSettings _dataBaseSettings)
        {

            var client = new MongoClient(_dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(_dataBaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_dataBaseSettings.ProductCollectionName);
            _mapper = mapper;
            _categoriesCollection = database.GetCollection<Category>(_dataBaseSettings.CategoryCollectionName);
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find<Product>(x => true).ToListAsync();
            var resultapper = _mapper.Map<List<ResultProductDto>>(values);
            return resultapper;
        }

        public async Task<GetByIdProductDto> GetByIdProductDtoAsync(string id)
        {
            var values = await _productCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            var resultmapper = _mapper.Map<GetByIdProductDto>(values);
            return resultmapper;
        }

        public async Task<List<ResultProductsWithCategory>> GetProductWithCategoryIdAsync(string categoryId)
        {
            var values = await _productCollection.Find(x => x.CategoryId == categoryId).ToListAsync();
            var result = _mapper.Map<List<ResultProductsWithCategory>>(values);
            return result;
        }

        public async Task<List<ResultProductsWithCategory>> ResultProductsWithCategoriesAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            var result = _mapper.Map<List<ResultProductsWithCategory>>(values);
            foreach (var item in result)
            {
                var categorytest = await _categoriesCollection.Find(x => x.CategoryId == item.CategoryId).Project(x => x.CategoryName).FirstOrDefaultAsync();
                item.CategoryName = categorytest;
            }

            return result;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
        }
    }
}
