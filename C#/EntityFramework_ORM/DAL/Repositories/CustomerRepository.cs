using DAL.Repositories;
using DAL.Entities;
using DAL.Data;

namespace DAL.Repositories;

public class CustomerRepository : GenericRepository<Customer, string>
{
    public CustomerRepository(MyAppDbContext context) : base(context)
    {
    }
}
