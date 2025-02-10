using Microsoft.Extensions.DependencyInjection;
using MultiShop.Cargo.DataAccessLayer.Abstracts;
using MultiShop.Cargo.DataAccessLayer.Repositories;

namespace MultiShop.Cargo.DataAccessLayer.Services;

public static class ServiceRegistration
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICargoDetailRepository, CargoDetailRepository>();
        services.AddScoped<ICargoCompanyRepository, CargoCompanyRepository>();
        services.AddScoped<ICargoCustomerRepository, CargoCustomerRepository>();
        services.AddScoped<ICargoOperationRepository, CargoOperationRepository>();
    }
}
