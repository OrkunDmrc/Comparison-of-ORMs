using DAL.Repositories;
using DAL.Entities;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class TerritoryRepository /*: GenericRepository<Territory, string>*/
{
    private MyAppDbContext _context;
    public TerritoryRepository(MyAppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Territory>> GetAllAsync() => await _context.Set<Territory>().ToListAsync();

    public async Task<Territory?> GetByIdAsync(string id) => await _context.Set<Territory>().FindAsync(id);

    public async Task<Territory> AddAsync(Territory entity)
    {
        await _context.Set<Territory>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Territory entity)
    {
        _context.Set<Territory>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<Territory>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
