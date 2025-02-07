using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController(IProductImageService _productImageService) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _productImageService.GetAllProductImageAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var value = await _productImageService.GetByIdProductImageAsync(id);

            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);

            return StatusCode(201, "Created Successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);

            return Ok("ProductImage updated successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);

            return Ok("ProductImage deleted successfully.");
        }
    }
}
