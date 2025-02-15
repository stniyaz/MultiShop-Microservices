using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos.BasketDtos;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketsController(ILoginService _loginService, IBasketService _basketService) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetBasket()
        => Ok(await _basketService.GetBasketAsync(_loginService.GetUserId));

    [HttpPost]
    public async Task<IActionResult> SaveBasket(BasketTotalDto basketTotalDto)
    {
        basketTotalDto.UserId = _loginService.GetUserId;

        await _basketService.SaveBasketAsync(basketTotalDto);
        return Ok("Changes to the cart have been saved.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBasket()
    {
        await _basketService.DeleteBasketAsync(_loginService.GetUserId);

        return Ok("Cart successfully deleted.");
    }
}
