﻿using MediatR;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class DeleteOrderingCommandHandler : IRequestHandler<DeleteOrderingRequest>
{
    private readonly IGenericRepository<Ordering> _repository;
    public DeleteOrderingCommandHandler(IGenericRepository<Ordering> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteOrderingRequest request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(await _repository.GetByIdAsync(request.Id));
    }
}
