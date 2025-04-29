using DAL.Repositories;
using DAL.Entities;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class ShipperRepository /*: GenericRepository<Shipper, int>*/
{
    private MyAppDbContext _context;
    public ShipperRepository(MyAppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Shipper>> GetAllAsync() => await _context.Set<Shipper>().ToListAsync();

    public async Task<Shipper?> GetByIdAsync(int id) => await _context.Set<Shipper>().FindAsync(id);

    public async Task<Shipper> AddAsync(Shipper entity)
    {
        await _context.Set<Shipper>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Shipper entity)
    {
        _context.Set<Shipper>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<Shipper>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
