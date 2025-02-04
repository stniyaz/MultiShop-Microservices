using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class UpdateOrderDetailCommandHandler
{
    private readonly IGenericRepository<OrderDetail> _repository;
    public UpdateOrderDetailCommandHandler(IGenericRepository<OrderDetail> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateOrderDetailCommand command)
    {
        await _repository.UpdateAsync(new OrderDetail
        {
            OrderDetailId = command.OrderDetailId,
            ProductCount = command.ProductCount,
            ProductId = command.ProductId,
            ProductName = command.ProductName,
            ProductPrice = command.ProductPrice,
            ProductTotalPrice = command.ProductTotalPrice,
            OrderingId = command.OrderingId,
        });
    }
}
