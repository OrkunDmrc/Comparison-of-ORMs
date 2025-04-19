using DAL.Repositories;
using DAL.Entities;

namespace DAL.Repositories;

public class CategoryRepository : GenericRepository<Category, int>
{
    public CategoryRepository(string connectionString) : base(connectionString, "Categories", "CategoryID")
    {
    }
}
