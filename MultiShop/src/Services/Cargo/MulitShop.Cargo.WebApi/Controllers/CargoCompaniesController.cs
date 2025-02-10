using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstracts;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;

namespace MulitShop.Cargo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CargoCompaniesController(ICargoCompanyService _cargoCompanyService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _cargoCompanyService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCargoOperationById(int id)
    {
        return Ok(await _cargoCompanyService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoOperation(CreateCargoCompanyDto createCargoCompanyDto)
    {
        await _cargoCompanyService.CreateAsync(createCargoCompanyDto);

        return Ok("Created Successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCargoOperation(UpdateCargoCompanyDto updateCargoCompanyDto)
    {
        await _cargoCompanyService.UpdateAsync(updateCargoCompanyDto);

        return Ok("Updated Successfully");
    }
}
