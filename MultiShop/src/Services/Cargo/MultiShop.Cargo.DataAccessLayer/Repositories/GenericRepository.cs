using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccessLayer.Abstracts;
using MultiShop.Cargo.DataAccessLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
{
    private readonly CargoContext _cargoContext;
    public GenericRepository(CargoContext cargoContext)
    {
        _cargoContext = cargoContext;
    }

    public async Task CreateAsync(T entity)
    {
        await _cargoContext.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _cargoContext.Set<T>().Remove(entity);
    }

    public async Task<List<T>> GetAllAsync()
        => await _cargoContext.Set<T>().ToListAsync();


    public async Task<T> GetByIdAsync(int id)
        => await _cargoContext.Set<T>().FindAsync(id);

    public async Task SaveChangeAsync()
    {
        await _cargoContext.SaveChangesAsync();
    }
}
