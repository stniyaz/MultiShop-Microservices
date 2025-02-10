using MultiShop.Cargo.DataAccessLayer.Abstracts;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Repositories;

public class CargoCustomerRepository : GenericRepository<CargoCustomer>, ICargoCustomerRepository
{
    public CargoCustomerRepository(CargoContext cargoContext) : base(cargoContext) { }
}
