using MultiShop.Cargo.BusinessLayer.Abstracts;
using MultiShop.Cargo.DataAccessLayer.Abstracts;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete;

public class CargoDetailService : ICargoDetailService
{
    private readonly ICargoDetailRepository _cargoDetailRepository;

    public CargoDetailService(ICargoDetailRepository cargoDetailRepository)
    {
        _cargoDetailRepository = cargoDetailRepository;
    }

    public async Task CreateAsync(CreateCargoDetailDto createCargoDetailDto)
    {
        await _cargoDetailRepository.CreateAsync(new CargoDetail
        {
            SenderCustomer = createCargoDetailDto.SenderCustomer,
            ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
            Barcode = createCargoDetailDto.Barcode,
            CargoCompanyId = createCargoDetailDto.CargoCompanyId
        });

        await _cargoDetailRepository.SaveChangeAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var value = await _cargoDetailRepository.GetByIdAsync(id);

        _cargoDetailRepository.Delete(value);

        await _cargoDetailRepository.SaveChangeAsync();
    }

    public async Task<List<CargoDetail>> GetAllAsync()
        => await _cargoDetailRepository.GetAllAsync();

    public async Task<CargoDetail> GetByIdAsync(int id)
        => await _cargoDetailRepository.GetByIdAsync(id);

    public async Task UpdateAsync(UpdateCargoDetailDto updateCargoDetailDto)
    {
        var value = await _cargoDetailRepository.GetByIdAsync(updateCargoDetailDto.CargoDetailId);

        value.SenderCustomer = updateCargoDetailDto.SenderCustomer;
        value.ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer;
        value.Barcode = updateCargoDetailDto.Barcode;
        value.CargoCompanyId = updateCargoDetailDto.CargoCompanyId;

        await _cargoDetailRepository.SaveChangeAsync();
    }
}
