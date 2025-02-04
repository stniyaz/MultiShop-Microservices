using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class CreateOrderDetailCommandHandler
{
    private readonly IGenericRepository<OrderDetail> _repository;
    public CreateOrderDetailCommandHandler(IGenericRepository<OrderDetail> repository)
    {
        _repository = repository;
    }
    public async Task Handle(CreateOrderDetailCommand command)
    {
        await _repository.CreateAsync(new OrderDetail
        {
            ProductId = command.ProductId,
            ProductName = command.ProductName,
            ProductCount = command.ProductCount,
            ProductPrice = command.ProductPrice,
            ProductTotalPrice = command.ProductTotalPrice,
            OrderingId = command.OrderingId,
        });
    }
}
