
using DAL.Entities;

namespace DAL.Repositories;

public class SupplierRepository : GenericRepository<Supplier, int>
{
    public SupplierRepository(string connectionString) : base(connectionString, "Suppliers", "SupplierID")
    {
    }
}
