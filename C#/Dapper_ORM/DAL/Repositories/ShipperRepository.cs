using DAL.Entities;
using Dapper;
using System.Data.SqlClient;

namespace DAL.Repositories;

public class ShipperRepository /*: GenericRepository<Shipper, int>*/
{
    private readonly string _connectionString;
    public ShipperRepository(string connectionString) /*: base(connectionString, "Shippers", "ShipperID")*/
    {
        _connectionString = connectionString;
    }
    [Obsolete]
    public async Task<List<Shipper>> GetAllAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"SELECT * FROM Shippers";
            var result = await connection.QueryAsync<Shipper>(query);
            return result.ToList();
        }
    }
    [Obsolete]
    public async Task<Shipper?> GetByIdAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = $"SELECT * FROM Shippers WHERE ShipperID = @Id";
            return await connection.QueryFirstOrDefaultAsync<Shipper>(query, new { Id = id });
        }
    }
    [Obsolete]
    public async Task<Shipper> AddAsync(Shipper entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"INSERT INTO Shippers (CompanyName, Phone) VALUES (@CompanyName, @Phone); SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = await connection.QuerySingleAsync<int>(query, entity);
            var propertyInfo = typeof(Shipper).GetProperty("ShipperID");
            propertyInfo.SetValue(entity, id);
            return entity;
        }
    }
    [Obsolete]
    public async Task UpdateAsync(Shipper entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"UPDATE Shippers SET CompanyName = @CompanyName, Phone = @Phone WHERE ShipperID = @ShipperID";
            await connection.ExecuteAsync(query, entity);
        }
    }
    [Obsolete]
    public async Task DeleteAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"DELETE FROM Shippers WHERE ShipperID = @Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
