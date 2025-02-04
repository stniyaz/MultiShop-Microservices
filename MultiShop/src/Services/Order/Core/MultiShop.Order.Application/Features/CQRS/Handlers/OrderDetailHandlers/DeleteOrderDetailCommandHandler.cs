using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class DeleteOrderDetailCommandHandler
{
    private readonly IGenericRepository<OrderDetail> _repsitory;
    public DeleteOrderDetailCommandHandler(IGenericRepository<OrderDetail> repsitory)
    {
        _repsitory = repsitory;
    }
    public async Task Handle(DeleteOrderDetailCommand command)
    {
        var value = await _repsitory.GetByIdAsync(command.Id);
        await _repsitory.DeleteAsync(value);
    }
}
