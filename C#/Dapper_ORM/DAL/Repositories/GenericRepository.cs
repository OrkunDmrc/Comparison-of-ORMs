using DAL.Interfaces;
using Dapper;
using System.Data.SqlClient;


namespace DAL.Repositories
{
    public class GenericRepository<T, Tkey> where T : class, IEntity
    {
        private readonly string _connectionString;
        private readonly string _tableName;
        private readonly string _primaryKey;
        public GenericRepository(string connectionString, string tableName, string primaryKey) 
        {
            _connectionString = connectionString;
            _tableName = tableName;
            _primaryKey = primaryKey;
        }

        [Obsolete]
        public async Task<List<T>> GetAllAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = $"SELECT * FROM {_tableName}";
                var result = await connection.QueryAsync<T>(query);
                return result.ToList();
            }
        }
        [Obsolete]
        public async Task<T?> GetByIdAsync(Tkey id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = $"SELECT * FROM {_tableName} WHERE {_primaryKey} = @Id";
                return await connection.QueryFirstOrDefaultAsync<T>(query, new { Id = id });
            }
        }
        [Obsolete]
        public async Task<T> AddAsync(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var columns = string.Join(", ", typeof(T).GetProperties().Where(p => p.Name != _primaryKey).Select(p => p.Name)).Replace(_primaryKey, "");
                var parameters = string.Join(", ", typeof(T).GetProperties().Where(p => p.Name != _primaryKey).Select(p => "@" + p.Name)).Replace($"@{_primaryKey}", "");
                var query = $"INSERT INTO {_tableName} ({columns}) VALUES ({parameters}); SELECT CAST(SCOPE_IDENTITY() as int);";
                var id = await connection.QuerySingleAsync<int>(query, entity);
                var propertyInfo = typeof(T).GetProperty(_primaryKey);
                propertyInfo.SetValue(entity, id);
                return entity;
            }
        }
        [Obsolete]
        public async Task<T> UpdateAsync(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var setClause = string.Join(", ", typeof(T).GetProperties()
                    .Where(p => p.Name != _primaryKey)
                    .Select(p => $"{p.Name} = @{p.Name}"));
                var propertyInfo = typeof(T).GetProperty(_primaryKey);
                var id = propertyInfo.GetValue(entity);
                var query = $"UPDATE {_tableName} SET {setClause} WHERE {_primaryKey} = {id}";
                await connection.ExecuteAsync(query, entity);
                return entity;
            }
        }
        [Obsolete]
        public async Task<T?> DeleteAsync(Tkey id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var entity = await connection.QueryFirstOrDefaultAsync<T>(
                    $"SELECT * FROM {_tableName} WHERE {_primaryKey} = @Id",
                    new { Id = id });
                if (entity == null)
                {
                    return null;
                }
                var query = $"DELETE FROM {_tableName} WHERE {_primaryKey} = @Id";
                await connection.ExecuteAsync(query, new { Id = id });
                return entity;
            }
        }
    }
}
