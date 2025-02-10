using MultiShop.Cargo.DataAccessLayer.Abstracts;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Repositories;

public class CargoOperationRepository : GenericRepository<CargoOperation>, ICargoOperationRepository
{
    public CargoOperationRepository(CargoContext cargoContext) : base(cargoContext) { }
}
