﻿using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
{
    private readonly IGenericRepository<Ordering> _repository;
    public GetOrderingByIdQueryHandler(IGenericRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);

        return new GetOrderingByIdQueryResult
        {
            OrderingId = value.OrderingId,
            UserId = value.UserId,
            TotalPrice = value.TotalPrice,
            OrderDate = value.OrderDate,
        };
    }
}
