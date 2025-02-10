using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Abstracts;

public interface ICargoOperationService
{
    Task CreateAsync(CreateCargoOperationDto createCargoOperationDto);
    Task UpdateAsync(UpdateCargoOperationDto updateCargoOperationDto);
    Task DeleteAsync(int id);
    Task<CargoOperation> GetByIdAsync(int id);
    Task<List<CargoOperation>> GetAllAsync();
}
