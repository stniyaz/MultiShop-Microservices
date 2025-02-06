using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Category> _CategoryCollection;
        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _CategoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        }
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
            => await _CategoryCollection.InsertOneAsync(_mapper.Map<Category>(createCategoryDto));

        public async Task DeleteCategoryAsync(string CategoryId)
            => await _CategoryCollection.DeleteOneAsync(x => x.CategoryId == CategoryId);

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
            => _mapper.Map<List<ResultCategoryDto>>(await _CategoryCollection.Find(x => true).ToListAsync());

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string CategoryId)
            => _mapper.Map<GetByIdCategoryDto>(await _CategoryCollection
                      .Find(x => x.CategoryId == CategoryId).FirstOrDefaultAsync());

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
            => await _CategoryCollection.FindOneAndReplaceAsync(x =>
                                            x.CategoryId == updateCategoryDto.CategoryId,
                                            _mapper.Map<Category>(updateCategoryDto));
    }
}
