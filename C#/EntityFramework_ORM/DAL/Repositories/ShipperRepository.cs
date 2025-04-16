using DAL.Repositories;
using DAL.Entities;
using DAL.Data;

namespace DAL.Repositories;

public class ShipperRepository : GenericRepository<Shipper, int>
{
    public ShipperRepository(MyAppDbContext context) : base(context)
    {
    }
}
