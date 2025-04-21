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

    public List<Order_Detail> GetAll() => _context.Set<Order_Detail>().ToList();

    public Order_Detail? GetById(int orderId, int productId) => _context.Set<Order_Detail>().First(e => e.OrderID == orderId && e.ProductID == productId);

    public Order_Detail Add(Order_Detail entity)
    {
        _context.Set<Order_Detail>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public Order_Detail? Delete(int orderId, int productId)
    {
        var entity = GetById(orderId, productId);
        if (entity != null)
        {
            _context.Set<Order_Detail>().Remove(entity);
            _context.SaveChanges();
        }
        return entity;
    }
}
