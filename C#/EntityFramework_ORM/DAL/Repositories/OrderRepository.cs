using DAL.Repositories;
using DAL.Entities;
using DAL.Data;

namespace DAL.Repositories;

public class OrderRepository : GenericRepository<Order, int>
{
    public OrderRepository(MyAppDbContext context) : base(context)
    {
    }
}
