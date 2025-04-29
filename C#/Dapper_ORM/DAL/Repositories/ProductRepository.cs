using DAL.Entities;
using Dapper;
using System.Data.SqlClient;


namespace DAL.Repositories;

public class ProductRepository /*: GenericRepository<Product, int>*/
{
    private readonly string _connectionString;
    public ProductRepository(string connectionString) /*: base(connectionString, "Products", "ProductID")*/
    {
        _connectionString = connectionString;
    }

    [Obsolete]
    public async Task<List<Product>> GetAllAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"SELECT * FROM Products";
            var result = await connection.QueryAsync<Product>(query);
            return result.ToList();
        }
    }
    [Obsolete]
    public async Task<Product?> GetByIdAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = $"SELECT * FROM Products WHERE ProductID = @Id";
            return await connection.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
        }
    }
    [Obsolete]
    public async Task<Product> AddAsync(Product entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)" +
                $" VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued); SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = await connection.QuerySingleAsync<int>(query, entity);
            var propertyInfo = typeof(Product).GetProperty("ProductID");
            propertyInfo.SetValue(entity, id);
            return entity;
        }
    }
    [Obsolete]
    public async Task UpdateAsync(Product entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"UPDATE Products SET ProductName = @ProductName, SupplierID = @SupplierID, CategoryID = @CategoryID, QuantityPerUnit = @QuantityPerUnit, UnitPrice = @UnitPrice," +
                $" UnitsInStock = @UnitsInStock, UnitsOnOrder = @UnitsOnOrder, ReorderLevel = @ReorderLevel, Discontinued = @Discontinued WHERE ProductID =  @ProductID";
            await connection.ExecuteAsync(query, entity);
        }
    }
    [Obsolete]
    public async Task DeleteAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"DELETE FROM Products WHERE ProductID = @Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
