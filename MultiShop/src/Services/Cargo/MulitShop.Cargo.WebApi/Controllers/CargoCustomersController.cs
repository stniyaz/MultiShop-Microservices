﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstracts;
using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;

namespace MulitShop.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCustomersController(ICargoCustomerService _cargoCustomerService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _cargoCustomerService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCargoOperationById(int id)
    {
        return Ok(await _cargoCustomerService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoOperation(CreateCargoCustomerDto createCargoCustomerDto)
    {
        await _cargoCustomerService.CreateAsync(createCargoCustomerDto);

        return Ok("Created Successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCargoOperation(UpdateCargoCustomerDto updateCargoCustomerDto)
    {
        await _cargoCustomerService.UpdateAsync(updateCargoCustomerDto);

        return Ok("Updated Successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCargoCompany(int id)
    {
        await _cargoCustomerService.DeleteAsync(id);
        return Ok("Deleted Successfully.");
    }
}
