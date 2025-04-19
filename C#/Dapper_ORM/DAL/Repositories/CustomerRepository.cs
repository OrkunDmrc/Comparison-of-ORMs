using DAL.Repositories;
using DAL.Entities;

namespace DAL.Repositories;

public class CustomerRepository : GenericRepository<Customer, string>
{
    public CustomerRepository(string connectionString) : base(connectionString, "Customers", "CustomerID")
    {
    }
}
