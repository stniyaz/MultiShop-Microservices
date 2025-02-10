using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Abstracts;

public interface ICargoCustomerService
{
    Task CreateAsync(CreateCargoCustomerDto createCargoCustomerDto);
    Task UpdateAsync(UpdateCargoCustomerDto updateCargoCustomerDto);
    Task DeleteAsync(int id);
    Task<CargoCustomer> GetByIdAsync(int id);
    Task<List<CargoCustomer>> GetAllAsync();
}
