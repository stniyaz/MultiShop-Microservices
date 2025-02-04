using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class DeleteAddressCommandHandler
{
    private readonly IGenericRepository<Address> _genericRepository;
    public DeleteAddressCommandHandler(IGenericRepository<Address> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task Handle(DeleteAddressCommand command)
    {
        var value = await _genericRepository.GetByIdAsync(command.AddressId);
        await _genericRepository.DeleteAsync(value);
    }
}
