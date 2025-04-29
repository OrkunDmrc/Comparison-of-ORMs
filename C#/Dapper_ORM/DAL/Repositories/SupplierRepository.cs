
using DAL.Entities;
using Dapper;
using System.Data.SqlClient;

namespace DAL.Repositories;

public class SupplierRepository /*: GenericRepository<Supplier, int>*/
{
    private readonly string _connectionString;
    public SupplierRepository(string connectionString) /*: base(connectionString, "Suppliers", "SupplierID")*/
    {
        _connectionString = connectionString;
    }
    [Obsolete]
    public async Task<List<Supplier>> GetAllAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"SELECT * FROM Suppliers";
            var result = await connection.QueryAsync<Supplier>(query);
            return result.ToList();
        }
    }
    [Obsolete]
    public async Task<Supplier?> GetByIdAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = $"SELECT * FROM Suppliers WHERE SupplierID = @Id";
            return await connection.QueryFirstOrDefaultAsync<Supplier>(query, new { Id = id });
        }
    }
    [Obsolete]
    public async Task<Supplier> AddAsync(Supplier entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"INSERT INTO Suppliers (CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage) " +
                $" VALUES (@CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax, @HomePage); SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = await connection.QuerySingleAsync<int>(query, entity);
            var propertyInfo = typeof(Supplier).GetProperty("SupplierID");
            propertyInfo.SetValue(entity, id);
            return entity;
        }
    }
    [Obsolete]
    public async Task UpdateAsync(Supplier entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"UPDATE Suppliers SET CompanyName = @CompanyName, ContactName = @ContactName, ContactTitle = @ContactTitle, Address = @Address, City = @City, Region = @Region," +
                $" PostalCode = @PostalCode, Country = @Country, Phone = @Phone, Fax = @Fax, HomePage = @HomePage WHERE SupplierID = @SupplierID";
            await connection.ExecuteAsync(query, entity);
        }
    }
    [Obsolete]
    public async Task DeleteAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"DELETE FROM Suppliers WHERE SupplierID = @Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
