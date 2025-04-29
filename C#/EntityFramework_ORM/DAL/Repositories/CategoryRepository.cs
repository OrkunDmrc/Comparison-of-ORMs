using DAL.Entities;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CategoryRepository /*: GenericRepository<Category, int>*/
{

    private MyAppDbContext _context;
    public CategoryRepository(MyAppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Category>> GetAllAsync() => await _context.Set<Category>().ToListAsync();

    public async Task<Category?> GetByIdAsync(int id) => await _context.Set<Category>().FindAsync(id);

    public async Task<Category> AddAsync(Category entity)
    {
        await _context.Set<Category>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Category entity)
    {
        _context.Set<Category>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<Category>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
