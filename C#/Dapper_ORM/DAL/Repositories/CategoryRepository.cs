using DAL.Repositories;
using DAL.Entities;
using System.Data.SqlClient;
using Dapper;

namespace DAL.Repositories;

public class CategoryRepository /*: GenericRepository<Category, int>*/
{
    private readonly string _connectionString;
    public CategoryRepository(string connectionString) /*: base(connectionString, "Categories", "CategoryID")*/
    {
        _connectionString = connectionString;
    }

    [Obsolete]
    public async Task<List<Category>> GetAllAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"SELECT * FROM Categories";
            var result = await connection.QueryAsync<Category>(query);
            return result.ToList();
        }
    }
    [Obsolete]
    public async Task<Category?> GetByIdAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = $"SELECT * FROM Categories WHERE CategoryID = @Id";
            return await connection.QueryFirstOrDefaultAsync<Category>(query, new { Id = id });
        }
    }
    [Obsolete]
    public async Task<Category> AddAsync(Category entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"INSERT INTO Categories (CategoryName, Description, Picture) VALUES (@CategoryName, @Description, @Picture); SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = await connection.QuerySingleAsync<int>(query, entity);
            var propertyInfo = typeof(Category).GetProperty("CategoryID");
            propertyInfo.SetValue(entity, id);
            return entity;
        }
    }
    [Obsolete]
    public async Task UpdateAsync(Category entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"UPDATE Categories SET CategoryName = @CategoryName, Description = @Description, Picture = @Picture WHERE CategoryID =  @CategoryID";
            await connection.ExecuteAsync(query, entity);
        }
    }
    [Obsolete]
    public async Task DeleteAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"DELETE FROM Categories WHERE CategoryID = @Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
