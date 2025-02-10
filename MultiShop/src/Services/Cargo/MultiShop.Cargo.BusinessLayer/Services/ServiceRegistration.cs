using Microsoft.Extensions.DependencyInjection;
using MultiShop.Cargo.BusinessLayer.Abstracts;
using MultiShop.Cargo.BusinessLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Services;

public static class ServiceRegistration
{
    public static async void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICargoCompanyService, CargoCompanyService>();
        services.AddScoped<ICargoCustomerService, CargoCustomerService>();
        services.AddScoped<ICargoDetailService, CargoDetailService>();
        services.AddScoped<ICargoOperationService, CargoOperationService>();
    }
}
