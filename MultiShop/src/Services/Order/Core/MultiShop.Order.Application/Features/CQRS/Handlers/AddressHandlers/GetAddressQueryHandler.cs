using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressQueryHandler
{
    private readonly IGenericRepository<Address> _genericRepository;
    public GetAddressQueryHandler(IGenericRepository<Address> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<List<GetAddressQueryResult>> Handle()
    {
        var values = await _genericRepository.GetAllAsync();

        return values.Select(x => new GetAddressQueryResult
        {
            AddressId = x.AddressId,
            UserId = x.UserId,
            Detail = x.Detail,
            City = x.City,
            District = x.District,
        }).ToList();
    }
}
