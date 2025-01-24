using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
            => await _productCollection.InsertOneAsync(_mapper.Map<Product>(createProductDto));

        public async Task DeleteProductAsync(string productId)
            => await _productCollection.DeleteOneAsync(x => x.ProductId == productId);

        public async Task<List<ResultProductDto>> GetAllProductAsync()
            => _mapper.Map<List<ResultProductDto>>(await _productCollection.Find(x => true).ToListAsync());

        public async Task<GetByIdProductDto> GetByIdProductAsync(string productId)
            => _mapper.Map<GetByIdProductDto>(await _productCollection
                      .Find(x => x.ProductId == productId).FirstOrDefaultAsync());

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
            => await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId,
                                                                   _mapper.Map<Product>(updateProductDto));
    }
}
