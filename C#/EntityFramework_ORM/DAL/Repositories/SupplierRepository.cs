using DAL.Repositories;
using DAL.Entities;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class SupplierRepository/* : GenericRepository<Supplier, int>*/
{
    private MyAppDbContext _context;
    public SupplierRepository(MyAppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Supplier>> GetAllAsync() => await _context.Set<Supplier>().ToListAsync();

    public async Task<Supplier?> GetByIdAsync(int id) => await _context.Set<Supplier>().FindAsync(id);

    public async Task<Supplier> AddAsync(Supplier entity)
    {
        await _context.Set<Supplier>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Supplier entity)
    {
        _context.Set<Supplier>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<Supplier>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
