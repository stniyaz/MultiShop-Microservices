using MultiShop.Cargo.BusinessLayer.Abstracts;
using MultiShop.Cargo.DataAccessLayer.Abstracts;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;
using System.Runtime.ConstrainedExecution;

namespace MultiShop.Cargo.BusinessLayer.Concrete;

public class CargoOperationService : ICargoOperationService
{
    private readonly ICargoOperationRepository _cargoOperationRepository;

    public CargoOperationService(ICargoOperationRepository cargoOperationRepository)
    {
        _cargoOperationRepository = cargoOperationRepository;
    }

    public async Task CreateAsync(CreateCargoOperationDto createCargoOperationDto)
    {
        await _cargoOperationRepository.CreateAsync(new CargoOperation
        {
            Barcode = createCargoOperationDto.Barcode,
            Description = createCargoOperationDto.Description,
            OpeartionDate = createCargoOperationDto.OpeartionDate,
        });

        await _cargoOperationRepository.SaveChangeAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var value = await _cargoOperationRepository.GetByIdAsync(id);

        _cargoOperationRepository.Delete(value);

        await _cargoOperationRepository.SaveChangeAsync();
    }

    public async Task<List<CargoOperation>> GetAllAsync()
        => await _cargoOperationRepository.GetAllAsync();

    public async Task<CargoOperation> GetByIdAsync(int id)
        => await _cargoOperationRepository.GetByIdAsync(id);

    public async Task UpdateAsync(UpdateCargoOperationDto updateCargoOperationDto)
    {
        var value = await _cargoOperationRepository.GetByIdAsync(updateCargoOperationDto.CargoOperationId);

        value.Barcode = updateCargoOperationDto.Barcode;
        value.Description = updateCargoOperationDto.Description;
        value.OpeartionDate = updateCargoOperationDto.OpeartionDate;

        await _cargoOperationRepository.SaveChangeAsync();
    }
}
