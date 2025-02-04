using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class UpdateAddressCommandHandler
{
    private readonly IGenericRepository<Address> _genericRepository;
    public UpdateAddressCommandHandler(IGenericRepository<Address> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task Handle(UpdateAddressCommand command)
    {
        await _genericRepository.UpdateAsync(new Address
        {
            AddressId = command.AddressId,
            UserId = command.UserId,
            City = command.City,
            District = command.District,
            Detail = command.Detail,
        });
    }
}
