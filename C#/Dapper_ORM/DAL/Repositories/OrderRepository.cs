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
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"SELECT * FROM Orders";
            var stopwatch = Stopwatch.StartNew();
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
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = $"SELECT * FROM Orders WHERE OrderID = @Id";
            var stopwatch = Stopwatch.StartNew();
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
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"INSERT INTO Orders (CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry)" +
                $" VALUES (@CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @ShippedDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry)";
            var stopwatch = Stopwatch.StartNew();
            await connection.QuerySingleAsync<int>(query, entity);
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
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"UPDATE Orders SET CustomerID = @CustomerID, EmployeeID = @EmployeeID, OrderDate = @OrderDate, RequiredDate = @RequiredDate, ShippedDate = @ShippedDate, " +
                $"ShipVia = @ShipVia, Freight = @Freight, ShipName = @ShipName, ShipAddress = @ShipAddress, ShipCity = @ShipCity, ShipRegion = @ShipRegion," +
                $" ShipPostalCode = @ShipPostalCode, ShipCountry = @ShipCountry WHERE OrderID =  @OrderID";
            var stopwatch = Stopwatch.StartNew();
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
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"DELETE FROM Orders WHERE OrderID = @Id";
            var stopwatch = Stopwatch.StartNew();
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
    [Obsolete]
    public async Task AllTablesTestAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"select o.*, e.*, c.*, s.*, od.*, p.*, ct.*, sp.*, et.*, t.*, r.* from Orders o" +
                $"\r\njoin Employees e on e.EmployeeID = o.EmployeeID\r\njoin Customers c on c.CustomerID = o.CustomerID" +
                $"\r\njoin Shippers s on s.ShipperID = o.ShipVia\r\njoin [Order Details] od on od.OrderID = o.OrderID" +
                $"\r\njoin Products p on p.ProductID = od.ProductID\r\njoin Categories ct on ct.CategoryID = p.CategoryID" +
                $"\r\njoin Suppliers sp on sp.SupplierID = p.SupplierID\r\njoin EmployeeTerritories et on et.EmployeeID = e.EmployeeID" +
                $"\r\njoin Territories t on t.TerritoryID = et.TerritoryID\r\njoin Region r on r.RegionID = t.RegionID";
            var stopwatch = Stopwatch.StartNew();
            var result = await connection.QueryAsync(query);
            stopwatch.Stop();
            await _testDatumRepository.AddAsync(new TestDatum
            {
                Language = "Net Core",
                TestName = "Dapper All Tables Operation",
                Performance = $"{stopwatch.ElapsedMilliseconds} ms",
                MemoryUsage = $"{/*(memAfter - memBefore) / 1024 / 1024*/0} MB",
                CpuUsage = $"{0} ms"
            });
        }
        
        
    }
}
