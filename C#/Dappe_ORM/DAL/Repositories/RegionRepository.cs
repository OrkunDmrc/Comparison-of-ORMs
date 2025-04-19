using DAL.Entities;

namespace DAL.Repositories;

public class RegionRepository : GenericRepository<Region, int>
{
    public RegionRepository(string connectionString) : base(connectionString, "Regions", "RegionID")
    {
    }
}
