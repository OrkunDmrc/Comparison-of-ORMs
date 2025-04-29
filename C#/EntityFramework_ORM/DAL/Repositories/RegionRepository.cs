using DAL.Repositories;
using DAL.Entities;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class RegionRepository /*: GenericRepository<Region, int>*/
{
    private MyAppDbContext _context;
    public RegionRepository(MyAppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Region>> GetAllAsync() => await _context.Set<Region>().ToListAsync();

    public async Task<Region?> GetByIdAsync(int id) => await _context.Set<Region>().FindAsync(id);

    public async Task<Region> AddAsync(Region entity)
    {
        await _context.Set<Region>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Region entity)
    {
        _context.Set<Region>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<Region>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
