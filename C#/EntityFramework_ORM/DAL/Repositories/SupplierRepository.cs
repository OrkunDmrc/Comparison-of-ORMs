using DAL.Repositories;
using DAL.Entities;
using DAL.Data;

namespace DAL.Repositories;

public class SupplierRepository : GenericRepository<Supplier, int>
{
    public SupplierRepository(MyAppDbContext context) : base(context)
    {
    }
}
