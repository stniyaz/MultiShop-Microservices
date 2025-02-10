using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Abstracts;

public interface ICargoCompanyService
{
    Task CreateAsync(CreateCargoCompanyDto createCargoCompanyDto);
    Task UpdateAsync(UpdateCargoCompanyDto updateCargoCompanyDto);
    Task DeleteAsync(int id);
    Task<CargoCompany> GetByIdAsync(int id);
    Task<List<CargoCompany>> GetAllAsync();
}
