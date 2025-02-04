using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;

public class DeleteOrderingRequest : IRequest
{
    public int Id { get; set; }
    public DeleteOrderingRequest(int id)
    {
        Id = id;
    }
}
