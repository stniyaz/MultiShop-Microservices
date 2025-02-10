using MultiShop.Cargo.DataAccessLayer.Abstracts;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Repositories;

public class CargoDetailRepository : GenericRepository<CargoDetail>, ICargoDetailRepository
{
    public CargoDetailRepository(CargoContext cargoContext) : base(cargoContext) { }
}
