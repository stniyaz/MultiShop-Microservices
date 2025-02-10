using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstracts;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;

namespace MulitShop.Cargo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CargoOperationsController(ICargoOperationService _cargoOperationService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _cargoOperationService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCargoOperationById(int id)
    {
        return Ok(await _cargoOperationService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoOperation(CreateCargoOperationDto createcargoOperationDto)
    {
        await _cargoOperationService.CreateAsync(createcargoOperationDto);

        return Ok("Created Successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDto updatecargoOperationDto)
    {
        await _cargoOperationService.UpdateAsync(updatecargoOperationDto);

        return Ok("Updated Successfully");
    }
}
