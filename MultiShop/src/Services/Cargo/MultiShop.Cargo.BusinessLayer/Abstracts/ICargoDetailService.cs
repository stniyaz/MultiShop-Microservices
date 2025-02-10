using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Abstracts;

public interface ICargoDetailService
{
    Task CreateAsync(CreateCargoDetailDto createCargoDetailDto);
    Task UpdateAsync(UpdateCargoDetailDto updateCargoDetailDto);
    Task DeleteAsync(int id);
    Task<CargoDetail> GetByIdAsync(int id);
    Task<List<CargoDetail>> GetAllAsync();
}
