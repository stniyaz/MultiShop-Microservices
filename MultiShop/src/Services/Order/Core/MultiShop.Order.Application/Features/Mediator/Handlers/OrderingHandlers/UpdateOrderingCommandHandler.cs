using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingRequest>
{
    private readonly IGenericRepository<Ordering> _repository;

    public UpdateOrderingCommandHandler(IGenericRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateOrderingRequest request, CancellationToken cancellationToken)
    {
        var number = request.OrderingId;
        var value = await _repository.GetByIdAsync(number);
        value.OrderDate = request.OrderDate;
        value.UserId = request.UserId;
        value.TotalPrice = request.TotalPrice;

        await _repository.UpdateAsync(value);
    }
}
