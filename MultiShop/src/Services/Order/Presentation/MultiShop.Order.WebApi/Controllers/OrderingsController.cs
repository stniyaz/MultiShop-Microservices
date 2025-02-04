using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultiShop.Order.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderingsController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _mediator.Send(new GetOrderingQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderingById(int id)
    {
        var value = await _mediator.Send(new GetOrderingByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrdering(CreateOrderingCommand createOrderingCommand)
    {
        await _mediator.Send(createOrderingCommand);
        return Ok("Created Successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrdering(UpdateOrderingRequest updateOrderingRequest)
    {
        await _mediator.Send(updateOrderingRequest);
        return Ok("Updated Successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrdering(int id)
    {
        await _mediator.Send(new DeleteOrderingRequest(id));
        return Ok("Deleted Successfully");
    }
}
