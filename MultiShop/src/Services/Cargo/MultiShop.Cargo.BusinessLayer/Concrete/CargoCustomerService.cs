using MultiShop.Cargo.BusinessLayer.Abstracts;
using MultiShop.Cargo.DataAccessLayer.Abstracts;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;
using System.Numerics;

namespace MultiShop.Cargo.BusinessLayer.Concrete;

public class CargoCustomerService : ICargoCustomerService
{
    private readonly ICargoCustomerRepository _cargoCustomerRepository;
    public CargoCustomerService(ICargoCustomerRepository cargoCustomerRepository)
    {
        _cargoCustomerRepository = cargoCustomerRepository;
    }

    public async Task CreateAsync(CreateCargoCustomerDto createCargoCustomerDto)
    {
        await _cargoCustomerRepository.CreateAsync(new CargoCustomer
        {
            Name = createCargoCustomerDto.Name,
            Surname = createCargoCustomerDto.Surname,
            Email = createCargoCustomerDto.Email,
            Phone = createCargoCustomerDto.Phone,
            City = createCargoCustomerDto.City,
            District = createCargoCustomerDto.District,
            Address = createCargoCustomerDto.Address,
            UserCustomerId = createCargoCustomerDto.UserCustomerId,
        });

        await _cargoCustomerRepository.SaveChangeAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var value = await _cargoCustomerRepository.GetByIdAsync(id);
        _cargoCustomerRepository.Delete(value);
        await _cargoCustomerRepository.SaveChangeAsync();
    }

    public async Task<List<CargoCustomer>> GetAllAsync()
        => await _cargoCustomerRepository.GetAllAsync();

    public async Task<CargoCustomer> GetByIdAsync(int id)
        => await _cargoCustomerRepository.GetByIdAsync(id);
    public async Task UpdateAsync(UpdateCargoCustomerDto updateCargoCustomerDto)
    {
        var value = await _cargoCustomerRepository.GetByIdAsync(updateCargoCustomerDto.CargoCustomerId);

        value.Name = updateCargoCustomerDto.Name;
        value.Surname = updateCargoCustomerDto.Surname;
        value.Email = updateCargoCustomerDto.Email;
        value.Phone = updateCargoCustomerDto.Phone;
        value.City = updateCargoCustomerDto.City;
        value.District = updateCargoCustomerDto.District;
        value.Address = updateCargoCustomerDto.Address;
        value.UserCustomerId = updateCargoCustomerDto.UserCustomerId;

        await _cargoCustomerRepository.SaveChangeAsync();
    }
}
