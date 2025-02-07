using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AddressesController(GetAddressByIdQueryHandler _getAddressByIdQueryHandler,
                                 GetAddressQueryHandler _getAddressQueryHandler,
                                 CreateAddressCommandHandler _createAddressCommandHandler,
                                 UpdateAddressCommandHandler _updateAddressCommandHandler,
                                 DeleteAddressCommandHandler _deleteAddressCommandHandler) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _getAddressQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddressById(int id)
    {
        var value = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAddress(CreateAddressCommand createAddressCommand)
    {
        await _createAddressCommandHandler.Handle(createAddressCommand);
        return Ok("Created Successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAddress(UpdateAddressCommand updateAddressCommand)
    {
        await _updateAddressCommandHandler.Handle(updateAddressCommand);
        return Ok("Updated Successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAddress(int id)
    {
        await _deleteAddressCommandHandler.Handle(new DeleteAddressCommand(id));
        return Ok("Deleted Successfully.");
    }
}
