using Dapper;
using System.Data.SqlClient;
using DAL.Entities;

namespace DAL.Repositories
{
    public class Order_DetailRepository
    {
        private readonly string _connectionString;

        public Order_DetailRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        [Obsolete]
        public async Task<List<Order_Detail>> GetAllAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM [Order Details]";
                return (await connection.QueryAsync<Order_Detail>(query)).AsList();
            }
        }

        [Obsolete]
        public async Task<Order_Detail?> GetByIdAsync(int orderId, int productId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM [Order Details] WHERE OrderID = @OrderId AND ProductID = @ProductId";
                return await connection.QueryFirstOrDefaultAsync<Order_Detail>(query, new { OrderId = orderId, ProductId = productId });
            }
        }

        [Obsolete]
        public async Task<Order_Detail> AddAsync(Order_Detail entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO [Order Details] (OrderID, ProductID, Quantity, UnitPrice) " +
                            "VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice);" +
                            "SELECT CAST(SCOPE_IDENTITY() as int);";
                var id = await connection.QuerySingleAsync<int>(query, entity);
                entity.OrderID = id;
                return entity;
            }
        }

        [Obsolete]
        public async Task DeleteAsync(int orderId, int productId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var deleteQuery = "DELETE FROM [Order Details] WHERE OrderID = @OrderId AND ProductID = @ProductId";
                await connection.ExecuteAsync(deleteQuery, new { OrderId = orderId, ProductId = productId });
            }
        }
    }
}

