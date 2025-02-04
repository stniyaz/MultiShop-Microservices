﻿using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
{
    private readonly IGenericRepository<Ordering> _repository;
    public GetOrderingQueryHandler(IGenericRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();

        return values.Select(x => new GetOrderingQueryResult
        {
            OrderingId = x.OrderingId,
            UserId = x.UserId,
            TotalPrice = x.TotalPrice,
            OrderDate = x.OrderDate,
        }).ToList();
    }
}
