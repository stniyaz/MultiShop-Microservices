using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailQueryHandler
{
    private readonly IGenericRepository<OrderDetail> _repository;
    public GetOrderDetailQueryHandler(IGenericRepository<OrderDetail> repository)
    {
        _repository = repository;
    }
    public async Task<List<GetOrderDetailQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();

        return values.Select(x => new GetOrderDetailQueryResult
        {
            OrderDetailId = x.OrderDetailId,
            ProductCount = x.ProductCount,
            ProductName = x.ProductName,
            ProductPrice = x.ProductPrice,
            ProductTotalPrice = x.ProductTotalPrice,
            ProductId = x.ProductId,
            OrderingId = x.OrderingId,
        }).ToList();
    }
}
