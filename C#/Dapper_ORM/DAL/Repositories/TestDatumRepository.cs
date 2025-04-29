
using DAL.Entities;
using Dapper;
using System.Data.SqlClient;

namespace DAL.Repositories;

public class TestDatumRepository /*: GenericRepository<TestDatum, int>*/
{
    private readonly string _connectionString;
    public TestDatumRepository(string connectionString) /*: base(connectionString, "TestData", "Id")*/
    {
        _connectionString = connectionString;
    }
    [Obsolete]
    public async Task<List<TestDatum>> GetAllAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"SELECT * FROM TestData";
            var result = await connection.QueryAsync<TestDatum>(query);
            return result.ToList();
        }
    }
    [Obsolete]
    public async Task<TestDatum?> GetByIdAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = $"SELECT * FROM TestData WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<TestDatum>(query, new { Id = id });
        }
    }
    [Obsolete]
    public async Task<TestDatum> AddAsync(TestDatum entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"INSERT INTO TestData (TestName, CpuUsage, MemoryUsage, Performance, Language)" +
                $" VALUES (@TestName, @CpuUsage, @MemoryUsage, @Performance, @Language); SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = await connection.QuerySingleAsync<int>(query, entity);
            var propertyInfo = typeof(TestDatum).GetProperty("Id");
            propertyInfo.SetValue(entity, id);
            return entity;
        }
    }
    [Obsolete]
    public async Task UpdateAsync(TestDatum entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"UPDATE TestData SET TestDatumName = @TestDatumName, Description = @Description, Picture = @Picture WHERE Id =  @Id";
            await connection.ExecuteAsync(query, entity);
        }
    }
    [Obsolete]
    public async Task DeleteAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"DELETE FROM TestData WHERE Id = @Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}

