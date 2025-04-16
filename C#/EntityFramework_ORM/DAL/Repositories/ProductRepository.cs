using DAL.Repositories;
using DAL.Entities;
using DAL.Data;


namespace DAL.Repositories;

public class ProductRepository : GenericRepository<Product, int>
{
    public ProductRepository(MyAppDbContext context) : base(context)
    {
    }
}
