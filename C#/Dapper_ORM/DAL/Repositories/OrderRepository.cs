using DAL.Repositories;
using DAL.Entities;
namespace DAL.Repositories;

public class OrderRepository : GenericRepository<Order, int>
{
    public OrderRepository(string connectionString) : base(connectionString, "Orders", "OrderID")
    {
    }
}
