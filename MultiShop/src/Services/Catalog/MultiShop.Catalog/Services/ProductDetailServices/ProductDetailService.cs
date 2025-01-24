using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductDetail> _ProductDetailCollection;
        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
        }
        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
            => await _ProductDetailCollection.InsertOneAsync(_mapper.Map<ProductDetail>(createProductDetailDto));

        public async Task DeleteProductDetailAsync(string ProductDetailId)
            => await _ProductDetailCollection.DeleteOneAsync(x => x.ProductDetailId == ProductDetailId);

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
            => _mapper.Map<List<ResultProductDetailDto>>(await _ProductDetailCollection.Find(x => true).ToListAsync());

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string ProductDetailId)
            => _mapper.Map<GetByIdProductDetailDto>(await _ProductDetailCollection
                      .Find(x => x.ProductDetailId == ProductDetailId).FirstOrDefaultAsync());

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
            => await _ProductDetailCollection.FindOneAndReplaceAsync(x =>
                                            x.ProductDetailId == updateProductDetailDto.ProductDetailId,
                                            _mapper.Map<ProductDetail>(updateProductDetailDto));
    }
}
