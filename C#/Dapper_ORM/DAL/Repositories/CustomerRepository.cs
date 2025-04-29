using DAL.Repositories;
using DAL.Entities;
using System.Data.SqlClient;
using Dapper;

namespace DAL.Repositories;

public class CustomerRepository /*: GenericRepository<Customer, string>*/
{
    private readonly string _connectionString;
    public CustomerRepository(string connectionString) /*: base(connectionString, "Customers", "CustomerID")*/
    {
        _connectionString = connectionString;
    }

    [Obsolete]
    public async Task<List<Customer>> GetAllAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"SELECT * FROM Customers";
            var result = await connection.QueryAsync<Customer>(query);
            return result.ToList();
        }
    }
    [Obsolete]
    public async Task<Customer?> GetByIdAsync(string id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = $"SELECT * FROM Customers WHERE CustomerID = @Id";
            return await connection.QueryFirstOrDefaultAsync<Customer>(query, new { Id = id });
        }
    }
    [Obsolete]
    public async Task<Customer> AddAsync(Customer entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"INSERT INTO Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) " +
                $"VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax); SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = await connection.QuerySingleAsync<int>(query, entity);
            var propertyInfo = typeof(Customer).GetProperty("CustomerID");
            propertyInfo.SetValue(entity, id);
            return entity;
        }
    }
    [Obsolete]
    public async Task UpdateAsync(Customer entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"UPDATE Customers SET CompanyName = @CompanyName, ContactName = @ContactName, ContactTitle = @ContactTitle, Address = @Address, City = @City, " +
                $"Region = @Region, PostalCode = @PostalCode, Country = @Country, Phone = @Phone, Fax = @Fax WHERE CustomerID =  @CustomerID";
            await connection.ExecuteAsync(query, entity);
        }
    }
    [Obsolete]
    public async Task DeleteAsync(string id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"DELETE FROM Customers WHERE CustomerID = @Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
