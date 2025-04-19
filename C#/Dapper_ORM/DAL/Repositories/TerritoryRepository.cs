using DAL.Repositories;
using DAL.Entities;

namespace DAL.Repositories;

public class TerritoryRepository : GenericRepository<Territory, string>
{
    public TerritoryRepository(string connectionString) : base(connectionString, "Territories", "TerritoryID")
    {
    }
}
