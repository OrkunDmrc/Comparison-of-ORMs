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

        public List<Order_Detail> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM [Order Details]";
                return connection.Query<Order_Detail>(query).ToList();
            }
        }

        public Order_Detail? GetById(int orderId, int productId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM [Order Details] WHERE OrderID = @OrderId AND ProductID = @ProductId";
                return connection.QueryFirstOrDefault<Order_Detail>(query, new { OrderId = orderId, ProductId = productId });
            }
        }

        public Order_Detail Add(Order_Detail entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO [Order Details] (OrderID, ProductID, Quantity, UnitPrice) " +
                            "VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice);" +
                            "SELECT CAST(SCOPE_IDENTITY() as int);";
                var id = connection.QuerySingle<int>(query, entity);
                entity.OrderID = id;
                return entity;
            }
        }

        public Order_Detail? Delete(int orderId, int productId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM [Order Details] WHERE OrderID = @OrderId AND ProductID = @ProductId";
                var entity = connection.QueryFirstOrDefault<Order_Detail>(query, new { OrderId = orderId, ProductId = productId });
                if (entity != null)
                {
                    var deleteQuery = "DELETE FROM [Order Details] WHERE OrderID = @OrderId AND ProductID = @ProductId";
                    connection.Execute(deleteQuery, new { OrderId = orderId, ProductId = productId });
                    return entity;
                }
                return null;
            }
        }
    }
}

