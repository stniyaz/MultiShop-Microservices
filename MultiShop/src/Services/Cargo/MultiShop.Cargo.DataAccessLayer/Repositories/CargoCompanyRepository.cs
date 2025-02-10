using MultiShop.Cargo.DataAccessLayer.Abstracts;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Repositories;

public class CargoCompanyRepository : GenericRepository<CargoCompany>, ICargoCompanyRepository
{
    public CargoCompanyRepository(CargoContext cargoContext) : base(cargoContext) { }
}
