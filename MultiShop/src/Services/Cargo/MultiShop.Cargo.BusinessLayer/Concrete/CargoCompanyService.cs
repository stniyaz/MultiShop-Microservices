using MultiShop.Cargo.BusinessLayer.Abstracts;
using MultiShop.Cargo.DataAccessLayer.Abstracts;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete;

public class CargoCompanyService : ICargoCompanyService
{
    private readonly ICargoCompanyRepository _cargoCompanyRepository;
    public CargoCompanyService(ICargoCompanyRepository cargoCompanyRepository)
    {
        _cargoCompanyRepository = cargoCompanyRepository;
    }
    public async Task CreateAsync(CreateCargoCompanyDto createCargoCompanyDto)
    {
        await _cargoCompanyRepository.CreateAsync(new CargoCompany
        {
            CompanyName = createCargoCompanyDto.CompanyName,
        });
        await _cargoCompanyRepository.SaveChangeAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var value = await _cargoCompanyRepository.GetByIdAsync(id);
        _cargoCompanyRepository.Delete(value);

        await _cargoCompanyRepository.SaveChangeAsync();
    }

    public async Task<List<CargoCompany>> GetAllAsync()
        => await _cargoCompanyRepository.GetAllAsync();

    public async Task<CargoCompany> GetByIdAsync(int id)
        => await _cargoCompanyRepository.GetByIdAsync(id);

    public async Task UpdateAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
    {
        var value = await _cargoCompanyRepository.GetByIdAsync(updateCargoCompanyDto.CargoCompanyId);

        value.CompanyName = updateCargoCompanyDto.CompanyName;

        await _cargoCompanyRepository.SaveChangeAsync();
    }
}
