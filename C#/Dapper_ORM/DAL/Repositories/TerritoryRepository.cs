using DAL.Repositories;
using DAL.Entities;
using System.Data.SqlClient;
using Dapper;

namespace DAL.Repositories;

public class TerritoryRepository /*: GenericRepository<Territory, string>*/
{
    private readonly string _connectionString;
    public TerritoryRepository(string connectionString) /*: base(connectionString, "Territories", "TerritoryID")*/
    {
        _connectionString = connectionString;
    }
    [Obsolete]
    public async Task<List<Territory>> GetAllAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"SELECT * FROM Territories";
            var result = await connection.QueryAsync<Territory>(query);
            return result.ToList();
        }
    }
    [Obsolete]
    public async Task<Territory?> GetByIdAsync(string id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = $"SELECT * FROM Territories WHERE TerritoryID = @Id";
            return await connection.QueryFirstOrDefaultAsync<Territory>(query, new { Id = id });
        }
    }
    [Obsolete]
    public async Task<Territory> AddAsync(Territory entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"INSERT INTO Territories (TerritoryID, TerritoryDescription, RegionID) VALUES (@TerritoryID, @TerritoryDescription, @RegionID); SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = await connection.QuerySingleAsync<int>(query, entity);
            var propertyInfo = typeof(Territory).GetProperty("TerritoryID");
            propertyInfo.SetValue(entity, id);
            return entity;
        }
    }
    [Obsolete]
    public async Task UpdateAsync(Territory entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"UPDATE Territories SET TerritoryDescription = @TerritoryDescription, RegionID = @RegionID WHERE TerritoryID =  @TerritoryID";
            await connection.ExecuteAsync(query, entity);
        }
    }
    [Obsolete]
    public async Task DeleteAsync(string id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"DELETE FROM Territories WHERE TerritoryID = @Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
