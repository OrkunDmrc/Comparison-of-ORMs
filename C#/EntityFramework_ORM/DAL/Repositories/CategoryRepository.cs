using DAL.Repositories;
using DAL.Entities;
using DAL.Data;

namespace DAL.Repositories;

public class CategoryRepository : GenericRepository<Category, int>
{
    public CategoryRepository(MyAppDbContext context) : base(context)
    {
    }
}
