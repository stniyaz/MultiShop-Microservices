﻿using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailByIdQueryHandler
{
    private readonly IGenericRepository<OrderDetail> _repository;
    public GetOrderDetailByIdQueryHandler(IGenericRepository<OrderDetail> repository)
    {
        _repository = repository;
    }
    public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
    {
        var value = await _repository.GetByIdAsync(query.Id);

        return new GetOrderDetailByIdQueryResult
        {
            OrderDetailId = value.OrderDetailId,
            ProductCount = value.ProductCount,
            ProductId = value.ProductId,
            ProductName = value.ProductName,
            ProductPrice = value.ProductPrice,
            ProductTotalPrice = value.ProductTotalPrice,
            OrderingId = value.OrderingId,
        };
    }
}
