using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressByIdQueryHandler
{
    private readonly IGenericRepository<Address> _genericRepository;
    public GetAddressByIdQueryHandler(IGenericRepository<Address> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery getAddressByIdQuery)
    {
        var value = await _genericRepository.GetByIdAsync(getAddressByIdQuery.Id);

        return new GetAddressByIdQueryResult
        {
            AddressId = value.AddressId,
            UserId = value.UserId,
            City = value.City,
            District = value.District,
            Detail = value.Detail,
        };
    }
}
