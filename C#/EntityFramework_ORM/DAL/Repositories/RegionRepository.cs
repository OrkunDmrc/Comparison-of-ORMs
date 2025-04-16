using DAL.Repositories;
using DAL.Entities;
using DAL.Data;

namespace DAL.Repositories;

public class RegionRepository : GenericRepository<Region, int>
{
    public RegionRepository(MyAppDbContext context) : base(context)
    {
    }
}
