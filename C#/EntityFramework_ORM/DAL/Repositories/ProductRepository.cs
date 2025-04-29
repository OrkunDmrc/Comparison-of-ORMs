using DAL.Repositories;
using DAL.Entities;
using DAL.Data;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repositories;

public class ProductRepository /*: GenericRepository<Product, int>*/
{
    private MyAppDbContext _context;
    public ProductRepository(MyAppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Product>> GetAllAsync() => await _context.Set<Product>().ToListAsync();

    public async Task<Product?> GetByIdAsync(int id) => await _context.Set<Product>().FindAsync(id);

    public async Task<Product> AddAsync(Product entity)
    {
        await _context.Set<Product>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Product entity)
    {
        _context.Set<Product>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<Product>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
