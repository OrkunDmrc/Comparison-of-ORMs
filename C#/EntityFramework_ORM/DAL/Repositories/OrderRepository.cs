using DAL.Entities;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DAL.Repositories;

public class OrderRepository /*: GenericRepository<Order, int>*/
{
    private MyAppDbContext _context;
    private TestDatumRepository _testDatumRepository;
    public OrderRepository(MyAppDbContext context, TestDatumRepository testDatumRepository)
    {
        _context = context;
        _testDatumRepository = testDatumRepository;
    }
    public async Task<List<Order>> GetAllAsync() 
    {
        var stopwatch = Stopwatch.StartNew();
        var entities = await _context.Set<Order>().ToListAsync();
        stopwatch.Stop();
        await _testDatumRepository.AddAsync(new TestDatum
        {
            Language = "Net Core",
            TestName = "EF Get All Operation",
            Performance = $"{stopwatch.ElapsedMilliseconds} ms",
            MemoryUsage = $"{/*(memAfter - memBefore) / 1024 / 1024*/0} MB",
            CpuUsage = $"{/*(cpuAfter - cpuBefore).TotalMilliseconds*/0} ms",
        });
        return entities;
    }

    public async Task<Order?> GetByIdAsync(int id) 
    {
        var stopwatch = Stopwatch.StartNew();
        var entity = await _context.Set<Order>().FindAsync(id);
        stopwatch.Stop();
        await _testDatumRepository.AddAsync(new TestDatum
        {
            Language = "Net Core",
            TestName = "EF Get Operation",
            Performance = $"{stopwatch.ElapsedMilliseconds} ms",
            MemoryUsage = $"{/*(memAfter - memBefore) / 1024 / 1024*/0} MB",
            CpuUsage = $"{0} ms",
        });
        return entity;
    }

    public async Task<Order> AddAsync(Order entity)
    {
        var stopwatch = Stopwatch.StartNew();
        await _context.Set<Order>().AddAsync(entity);
        await _context.SaveChangesAsync();
        stopwatch.Stop();
        await _testDatumRepository.AddAsync(new TestDatum
        {
            Language = "Net Core",
            TestName = "EF Create Operation",
            Performance = $"{stopwatch.ElapsedMilliseconds} ms",
            MemoryUsage = $"{/*(memAfter - memBefore) / 1024 / 1024*/0} MB",
            CpuUsage = $"{0} ms",
        });
        return entity;
    }

    public async Task UpdateAsync(Order entity)
    {
        var stopwatch = Stopwatch.StartNew();
        _context.Set<Order>().Update(entity);
        await _context.SaveChangesAsync();
        stopwatch.Stop();
        await _testDatumRepository.AddAsync(new TestDatum
        {
            Language = "Net Core",
            TestName = "EF Update Operation",
            Performance = $"{stopwatch.ElapsedMilliseconds} ms",
            MemoryUsage = $"{/*(memAfter - memBefore) / 1024 / 1024*/0} MB",
            CpuUsage = $"{0} ms",
        });
    }

    public async Task DeleteAsync(int id)
    {
        var stopwatch = Stopwatch.StartNew();
        var entity = await _context.Set<Order>().FindAsync(id);
        _context.Set<Order>().Remove(entity!);
        await _context.SaveChangesAsync();
        stopwatch.Stop();
        await _testDatumRepository.AddAsync(new TestDatum
        {
            Language = "Net Core",
            TestName = "EF Delete Operation",
            Performance = $"{stopwatch.ElapsedMilliseconds} ms",
            MemoryUsage = $"{/*(memAfter - memBefore) / 1024 / 1024*/0} MB",
            CpuUsage = $"{0} ms",
        });
    }

    public async Task AllTablesTestAsync()
    {
        var stopwatch = Stopwatch.StartNew();
        var query = from o in _context.Orders
                    join e in _context.Employees on o.EmployeeID equals e.EmployeeID
                    join c in _context.Customers on o.CustomerID equals c.CustomerID
                    join s in _context.Shippers on o.ShipVia equals s.ShipperID
                    join od in _context.Order_Details on o.OrderID equals od.OrderID
                    join p in _context.Products on od.ProductID equals p.ProductID
                    join ct in _context.Categories on p.CategoryID equals ct.CategoryID
                    join sp in _context.Suppliers on p.SupplierID equals sp.SupplierID
                    join et in _context.EmployeeTerritories on e.EmployeeID equals et.EmployeeID
                    join t in _context.Territories on et.TerritoryID equals t.TerritoryID
                    join r in _context.Regions on t.RegionID equals r.RegionID
                    select new
                    {
                        Order = o,
                        Employee = e,
                        Customer = c,
                        Shipper = s,
                        OrderDetail = od,
                        Product = p,
                        Category = ct,
                        Supplier = sp,
                        EmployeeTerritory = et,
                        Territory = t,
                        Region = r
                    };
        var results = await query.ToListAsync();
        stopwatch.Stop();
        await _testDatumRepository.AddAsync(new TestDatum
        {
            Language = "Net Core",
            TestName = "EF All Tables Operation",
            Performance = $"{stopwatch.ElapsedMilliseconds} ms",
            MemoryUsage = $"{/*(memAfter - memBefore) / 1024 / 1024*/0} MB",
            CpuUsage = $"{0} ms"
        });
    }
}
