using MultiShop.Discount.Dtos.CouponDtos;

namespace MultiShop.Discount.Services.DiscountServices;

public interface IDiscountService
{
    Task CreateCouponAsync(CreateCouponDto createCouponDto);
    Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
    Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
    Task<List<ResultCouponDto>> GetAllCouponAsync();
    Task DeleteCouponAsync(int id);
}
