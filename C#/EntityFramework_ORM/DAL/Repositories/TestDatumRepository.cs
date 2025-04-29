using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TestDatumRepository /*: GenericRepository<TestDatum, int>*/
    {
        private MyAppDbContext _context;
    public TestDatumRepository(MyAppDbContext context)
    {
        _context = context;
    }
    public async Task<List<TestDatum>> GetAllAsync() => await _context.Set<TestDatum>().ToListAsync();

    public async Task<TestDatum?> GetByIdAsync(int id) => await _context.Set<TestDatum>().FindAsync(id);

    public async Task<TestDatum> AddAsync(TestDatum entity)
    {
        await _context.Set<TestDatum>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(TestDatum entity)
    {
        _context.Set<TestDatum>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<TestDatum>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
    }
}
