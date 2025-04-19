using DAL.Entities;

namespace DAL.Repositories;

public class ShipperRepository : GenericRepository<Shipper, int>
{
    public ShipperRepository(string connectionString) : base(connectionString, "Shippers", "ShipperID")
    {
    }
}
