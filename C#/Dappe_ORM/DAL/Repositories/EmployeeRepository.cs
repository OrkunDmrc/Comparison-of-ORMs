using DAL.Repositories;
using DAL.Entities;
namespace DAL.Repositories;

public class EmployeeRepository : GenericRepository<Employee, int>
{
    public EmployeeRepository(string connectionString) : base(connectionString, "Eployees", "EmployeeID")
    {
    }
}
