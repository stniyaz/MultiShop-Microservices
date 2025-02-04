using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

namespace MultiShop.Order.Application.Services;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<CreateAddressCommandHandler>();
        services.AddScoped<UpdateAddressCommandHandler>();
        services.AddScoped<DeleteAddressCommandHandler>();
        services.AddScoped<GetAddressByIdQueryHandler>();
        services.AddScoped<GetAddressQueryHandler>();
        
        services.AddScoped<CreateOrderDetailCommandHandler>();
        services.AddScoped<UpdateOrderDetailCommandHandler>();
        services.AddScoped<DeleteOrderDetailCommandHandler>();
        services.AddScoped<GetOrderDetailByIdQueryHandler>();
        services.AddScoped<GetOrderDetailQueryHandler>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
    }
}
