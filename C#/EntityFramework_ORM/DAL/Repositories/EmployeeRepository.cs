using DAL.Repositories;
using DAL.Entities;
using DAL.Data;

namespace DAL.Repositories;

public class EmployeeRepository : GenericRepository<Employee, int>
{
    public EmployeeRepository(MyAppDbContext context) : base(context)
    {
    }
}
