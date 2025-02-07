using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos.CouponDtos;
using MultiShop.Discount.Services.DiscountServices;

namespace MultiShop.Discount.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DiscountsController(IDiscountService _discountService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _discountService.GetAllCouponAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCouponById(int id)
    {
        return Ok(await _discountService.GetByIdCouponAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
    {
        await _discountService.CreateCouponAsync(createCouponDto);
        return StatusCode(201, "Created Successfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCoupon(int id)
    {
        await _discountService.DeleteCouponAsync(id);

        return Ok("Deleted Successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
    {
        await _discountService.UpdateCouponAsync(updateCouponDto);

        return Ok("Updated Successfully.");
    }
}
