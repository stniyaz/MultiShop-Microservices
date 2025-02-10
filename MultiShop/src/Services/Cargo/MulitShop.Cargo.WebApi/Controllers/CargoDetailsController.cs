using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstracts;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;

namespace MulitShop.Cargo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CargoDetailsController(ICargoDetailService _cargoDetailService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _cargoDetailService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCargoDetailById(int id)
    {
        return Ok(await _cargoDetailService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
    {
        await _cargoDetailService.CreateAsync(createCargoDetailDto);

        return Ok("Created Successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
    {
        await _cargoDetailService.UpdateAsync(updateCargoDetailDto);

        return Ok("Updated Successfully");
    }
}
