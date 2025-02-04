using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController(CreateOrderDetailCommandHandler _createOrderDetailCommandHandler,
                                    UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler,
                                    DeleteOrderDetailCommandHandler _deleteOrderDetailCommandHandler,
                                    GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler,
                                    GetOrderDetailQueryHandler _getOrderDetailQueryHandler) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var values = await _getOrderDetailQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddressById(int id)
    {
        var value = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand createOrderDetailCommand)
    {
        await _createOrderDetailCommandHandler.Handle(createOrderDetailCommand);
        return Ok("Created Successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand updateOrderDetailCommand)
    {
        await _updateOrderDetailCommandHandler.Handle(updateOrderDetailCommand);
        return Ok("Updated Successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrderDetail(int id)
    {
        await _deleteOrderDetailCommandHandler.Handle(new DeleteOrderDetailCommand(id));
        return Ok("Deleted Successfully.");
    }
}
