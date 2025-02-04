using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class CreateAddressCommandHandler
{
    private readonly IGenericRepository<Address> _genericRepository;
    public CreateAddressCommandHandler(IGenericRepository<Address> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task Handle(CreateAddressCommand command)
    {
        await _genericRepository.CreateAsync(new Address
        {
            UserId = command.UserId,
            District = command.District,
            City = command.City,
            Detail = command.Detail
        });
    }
}
