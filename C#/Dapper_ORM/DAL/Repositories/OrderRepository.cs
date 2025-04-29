using DAL.Repositories;
using DAL.Entities;
using System.Data.SqlClient;
using Dapper;
namespace DAL.Repositories;

public class OrderRepository /*: GenericRepository<Order, int>*/
{
    private readonly string _connectionString;
    public OrderRepository(string connectionString) /*: base(connectionString, "Orders", "OrderID")*/
    {
        _connectionString = connectionString;
    }

    [Obsolete]
    public async Task<List<Order>> GetAllAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"SELECT * FROM Orders";
            var result = await connection.QueryAsync<Order>(query);
            return result.ToList();
        }
    }
    [Obsolete]
    public async Task<Order?> GetByIdAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = $"SELECT * FROM Orders WHERE OrderID = @Id";
            return await connection.QueryFirstOrDefaultAsync<Order>(query, new { Id = id });
        }
    }
    [Obsolete]
    public async Task<Order> AddAsync(Order entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"INSERT INTO Orders (CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry)" +
                $" VALUES (@CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @ShippedDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry); SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = await connection.QuerySingleAsync<int>(query, entity);
            var propertyInfo = typeof(Order).GetProperty("OrderID");
            propertyInfo.SetValue(entity, id);
            return entity;
        }
    }
    [Obsolete]
    public async Task UpdateAsync(Order entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"UPDATE Orders SET CustomerID = @CustomerID, EmployeeID = @EmployeeID, OrderDate = @OrderDate, RequiredDate = @RequiredDate, ShippedDate = @ShippedDate, " +
                $"ShipVia = @ShipVia, Freight = @Freight, ShipName = @ShipName, ShipAddress = @ShipAddress, ShipCity = @ShipCity, ShipRegion = @ShipRegion," +
                $" ShipPostalCode = @ShipPostalCode, ShipCountry = @ShipCountry WHERE OrderID =  @OrderID";
            await connection.ExecuteAsync(query, entity);
        }
    }
    [Obsolete]
    public async Task DeleteAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"DELETE FROM Orders WHERE OrderID = @Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
