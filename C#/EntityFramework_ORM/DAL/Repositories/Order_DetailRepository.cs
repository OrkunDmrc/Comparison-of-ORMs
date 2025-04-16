using DAL.Repositories;
using DAL.Entities;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class Order_DetailRepository
{
    private readonly MyAppDbContext _context;
    public Order_DetailRepository(MyAppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Order_Detail>> GetAllAsync() => await _context.Set<Order_Detail>().ToListAsync();

    public async Task<Order_Detail?> GetByIdAsync(int orderId, int productId) => await _context.Set<Order_Detail>().FirstAsync(e => e.OrderID == orderId && e.ProductID == productId);

    public async Task<Order_Detail> AddAsync(Order_Detail entity)
    {
        await _context.Set<Order_Detail>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Order_Detail?> DeleteAsync(int orderId, int productId)
    {
        var entity = await GetByIdAsync(orderId, productId);
        if (entity != null)
        {
            _context.Set<Order_Detail>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        return entity;
    }
}
