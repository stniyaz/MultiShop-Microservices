using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductService
    {
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task<GetByIdProductDto> GetByIdProductAsync(string productId);
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task DeleteProductAsync(string productId);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
    }
}
