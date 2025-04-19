using DAL.Entities;


namespace DAL.Repositories;

public class ProductRepository : GenericRepository<Product, int>
{
    public ProductRepository(string connectionString) : base(connectionString, "Products", "ProductID")
    {
    }
}
