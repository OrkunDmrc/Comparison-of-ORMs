using DAL.Repositories;
using DAL.Entities;
using DAL.Data;

namespace DAL.Repositories;

public class TerritoryRepository : GenericRepository<Territory, string>
{
    public TerritoryRepository(MyAppDbContext context) : base(context)
    {
    }
}
