using DAL.Entities;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class OrderRepository /*: GenericRepository<Order, int>*/
{
    private MyAppDbContext _context;
    public OrderRepository(MyAppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Order>> GetAllAsync() => await _context.Set<Order>().ToListAsync();

    public async Task<Order?> GetByIdAsync(int id) => await _context.Set<Order>().FindAsync(id);

    public async Task<Order> AddAsync(Order entity)
    {
        await _context.Set<Order>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Order entity)
    {
        _context.Set<Order>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<Order>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
