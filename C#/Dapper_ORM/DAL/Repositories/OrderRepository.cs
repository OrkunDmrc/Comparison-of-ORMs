using DAL.Repositories;
using DAL.Entities;
using System.Data.SqlClient;
using Dapper;
using System.Diagnostics;
namespace DAL.Repositories;

public class OrderRepository /*: GenericRepository<Order, int>*/
{
    private readonly string _connectionString;
    private readonly TestDatumRepository _testDatumRepository;
    public OrderRepository(string connectionString, TestDatumRepository testDatumRepository) /*: base(connectionString, "Orders", "OrderID")*/
    {
        _connectionString = connectionString;
        _testDatumRepository = testDatumRepository;
    }

    [Obsolete]
    public async Task<List<Order>> GetAllAsync()
    {
        var stopwatch = Stopwatch.StartNew();
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"SELECT * FROM Orders";
            var result = await connection.QueryAsync<Order>(query);
            stopwatch.Stop();
            await _testDatumRepository.AddAsync(new TestDatum
            {
                Language = "Net Core",
                TestName = "Dapper Get All Operation",
                Performance = $"{stopwatch.ElapsedMilliseconds} ms",
                MemoryUsage = $"{/*(memAfter - memBefore) / 1024 / 1024*/0} MB",
                CpuUsage = $"{/*(cpuAfter - cpuBefore).TotalMilliseconds*/0} ms",
            });
            return result.ToList();
        }
    }
    [Obsolete]
    public async Task<Order?> GetByIdAsync(int id)
    {
        var stopwatch = Stopwatch.StartNew();
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = $"SELECT * FROM Orders WHERE OrderID = @Id";
            var result = await connection.QueryFirstOrDefaultAsync<Order>(query, new { Id = id });
            stopwatch.Stop();
            await _testDatumRepository.AddAsync(new TestDatum
            {
                Language = "Net Core",
                TestName = "Dapper Get Operation",
                Performance = $"{stopwatch.ElapsedMilliseconds} ms",
                MemoryUsage = $"{/*(memAfter - memBefore) / 1024 / 1024*/0} MB",
                CpuUsage = $"{/*(cpuAfter - cpuBefore).TotalMilliseconds*/0} ms",
            });
            return result;
        }
    }
    [Obsolete]
    public async Task<Order> AddAsync(Order entity)
    {
        var stopwatch = Stopwatch.StartNew();
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"INSERT INTO Orders (CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry)" +
                $" VALUES (@CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @ShippedDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry); SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = await connection.QuerySingleAsync<int>(query, entity);
            var propertyInfo = typeof(Order).GetProperty("OrderID");
            propertyInfo.SetValue(entity, id);
            stopwatch.Stop();
            await _testDatumRepository.AddAsync(new TestDatum
            {
                Language = "Net Core",
                TestName = "Dapper Create Operation",
                Performance = $"{stopwatch.ElapsedMilliseconds} ms",
                MemoryUsage = $"{/*(memAfter - memBefore) / 1024 / 1024*/0} MB",
                CpuUsage = $"{/*(cpuAfter - cpuBefore).TotalMilliseconds*/0} ms",
            });
            return entity;
        }
    }
    [Obsolete]
    public async Task UpdateAsync(Order entity)
    {
        var stopwatch = Stopwatch.StartNew();
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"UPDATE Orders SET CustomerID = @CustomerID, EmployeeID = @EmployeeID, OrderDate = @OrderDate, RequiredDate = @RequiredDate, ShippedDate = @ShippedDate, " +
                $"ShipVia = @ShipVia, Freight = @Freight, ShipName = @ShipName, ShipAddress = @ShipAddress, ShipCity = @ShipCity, ShipRegion = @ShipRegion," +
                $" ShipPostalCode = @ShipPostalCode, ShipCountry = @ShipCountry WHERE OrderID =  @OrderID";
            await connection.ExecuteAsync(query, entity);
            stopwatch.Stop();
            await _testDatumRepository.AddAsync(new TestDatum
            {
                Language = "Net Core",
                TestName = "Dapper Update Operation",
                Performance = $"{stopwatch.ElapsedMilliseconds} ms",
                MemoryUsage = $"{/*(memAfter - memBefore) / 1024 / 1024*/0} MB",
                CpuUsage = $"{/*(cpuAfter - cpuBefore).TotalMilliseconds*/0} ms",
            });
        }
    }
    [Obsolete]
    public async Task DeleteAsync(int id)
    {
        var stopwatch = Stopwatch.StartNew();
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"DELETE FROM Orders WHERE OrderID = @Id";
            await connection.ExecuteAsync(query, new { Id = id });
            stopwatch.Stop();
            await _testDatumRepository.AddAsync(new TestDatum
            {
                Language = "Net Core",
                TestName = "Dapper Delete Operation",
                Performance = $"{stopwatch.ElapsedMilliseconds} ms",
                MemoryUsage = $"{/*(memAfter - memBefore) / 1024 / 1024*/0} MB",
                CpuUsage = $"{/*(cpuAfter - cpuBefore).TotalMilliseconds*/0} ms",
            });
        }
    }
}
