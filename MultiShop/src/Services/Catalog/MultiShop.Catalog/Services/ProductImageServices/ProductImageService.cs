using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImage> _ProductImageCollection;
        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
        }
        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
            => await _ProductImageCollection.InsertOneAsync(_mapper.Map<ProductImage>(createProductImageDto));

        public async Task DeleteProductImageAsync(string ProductImageId)
            => await _ProductImageCollection.DeleteOneAsync(x => x.ProductImageId == ProductImageId);

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
            => _mapper.Map<List<ResultProductImageDto>>(await _ProductImageCollection.Find(x => true).ToListAsync());

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string ProductImageId)
            => _mapper.Map<GetByIdProductImageDto>(await _ProductImageCollection
                      .Find(x => x.ProductImageId == ProductImageId).FirstOrDefaultAsync());

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
            => await _ProductImageCollection.FindOneAndReplaceAsync(x =>
                                           x.ProductImageId == updateProductImageDto.ProductImageId,
                                           _mapper.Map<ProductImage>(updateProductImageDto));
    }
}
