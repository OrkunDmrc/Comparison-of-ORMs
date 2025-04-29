using DAL.Entities;
using Dapper;
using System.Data.SqlClient;

namespace DAL.Repositories;

public class RegionRepository /*: GenericRepository<Region, int>*/
{
    private readonly string _connectionString;
    public RegionRepository(string connectionString) /*: base(connectionString, "Regions", "RegionID")*/
    {
        _connectionString = connectionString;
    }
    [Obsolete]
    public async Task<List<Region>> GetAllAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"SELECT * FROM Region";
            var result = await connection.QueryAsync<Region>(query);
            return result.ToList();
        }
    }
    [Obsolete]
    public async Task<Region?> GetByIdAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = $"SELECT * FROM Region WHERE RegionID = @Id";
            return await connection.QueryFirstOrDefaultAsync<Region>(query, new { Id = id });
        }
    }
    [Obsolete]
    public async Task<Region> AddAsync(Region entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"INSERT INTO Region (RegionID, RegionDescription) VALUES (@RegionID, @RegionDescription); SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = await connection.QuerySingleAsync<int>(query, entity);
            var propertyInfo = typeof(Region).GetProperty("RegionID");
            propertyInfo.SetValue(entity, id);
            return entity;
        }
    }
    [Obsolete]
    public async Task UpdateAsync(Region entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"UPDATE Region SET RegionDescription = @RegionDescription WHERE RegionID =  @RegionID";
            await connection.ExecuteAsync(query, entity);
        }
    }
    [Obsolete]
    public async Task DeleteAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"DELETE FROM Region WHERE RegionID = @Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
