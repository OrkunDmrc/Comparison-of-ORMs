using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System.Diagnostics;

namespace BLL.Services;

public class OrderService /*: IService<Order, int>*/
{
    private readonly OrderRepository _repository;
    private readonly TestDatumRepository _testDatumRepository;

    public OrderService(OrderRepository repository, TestDatumRepository testDatumRepository)
    {
        _repository = repository;
        _testDatumRepository = testDatumRepository;
    }

    public async Task<Order> AddAsync(Order entity)
    {
        var stopwatch = Stopwatch.StartNew();
        await _repository.AddAsync(entity);
        stopwatch.Stop();

        var memBefore = Process.GetCurrentProcess().WorkingSet64;
        await _repository.AddAsync(entity);
        var memAfter = Process.GetCurrentProcess().WorkingSet64;

        TestDatum testDatum = new TestDatum
        {
            Language = "Net Core",
            TestName = "EF Create Operation",
            Performance = $"{stopwatch.ElapsedMilliseconds} ms",
            MemoryUsage = $"{(memAfter - memBefore) / 1024 / 1024} MB",
            CpuUsage = $"{/*(cpuAfter - cpuBefore).TotalMilliseconds*/0} ms",
        };

        await _testDatumRepository.AddAsync(testDatum);
        return entity;

    }

    public async Task DeleteAsync(int id)
    {
        var stopwatch = Stopwatch.StartNew();
        await _repository.DeleteAsync(id);
        stopwatch.Stop();

        var memBefore = Process.GetCurrentProcess().WorkingSet64;
        await _repository.DeleteAsync(id);
        var memAfter = Process.GetCurrentProcess().WorkingSet64;

        TestDatum testDatum = new TestDatum
        {
            Language = "Net Core",
            TestName = "EF Delete Operation",
            Performance = $"{stopwatch.ElapsedMilliseconds} ms",
            MemoryUsage = $"{(memAfter - memBefore) / 1024 / 1024} MB",
            CpuUsage = $"{/*(cpuAfter - cpuBefore).TotalMilliseconds*/0} ms",
        };

        await _testDatumRepository.AddAsync(testDatum);
    }

    public async Task<List<Order>> GetAllAsync()
    {
        var stopwatch = Stopwatch.StartNew();
        var entities = await _repository.GetAllAsync();
        stopwatch.Stop();

        var memBefore = Process.GetCurrentProcess().WorkingSet64;
        var entities2 = await _repository.GetAllAsync();
        var memAfter = Process.GetCurrentProcess().WorkingSet64;

        TestDatum testDatum = new TestDatum
        {
            Language = "Net Core",
            TestName = "EF Get All Operation",
            Performance = $"{stopwatch.ElapsedMilliseconds} ms",
            MemoryUsage = $"{(memAfter - memBefore) / 1024 / 1024} MB",
            CpuUsage = $"{/*(cpuAfter - cpuBefore).TotalMilliseconds*/0} ms",
        };
        await _testDatumRepository.AddAsync(testDatum);

        return entities;
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        var stopwatch = Stopwatch.StartNew();
        var entity = await _repository.GetByIdAsync(id);
        stopwatch.Stop();

        var memBefore = Process.GetCurrentProcess().WorkingSet64;
        var entity2 = await _repository.GetByIdAsync(id);
        var memAfter = Process.GetCurrentProcess().WorkingSet64;

        TestDatum testDatum = new TestDatum
        {
            Language = "Net Core",
            TestName = "EF Get Operation",
            Performance = $"{stopwatch.ElapsedMilliseconds} ms",
            MemoryUsage = $"{(memAfter - memBefore) / 1024 / 1024} MB",
            CpuUsage = $"{0} ms",
        };

        await _testDatumRepository.AddAsync(testDatum);

        return entity;
    }

    public async Task UpdateAsync(Order entity)
    {
        var stopwatch = Stopwatch.StartNew();
        await _repository.UpdateAsync(entity);
        stopwatch.Stop();

        var memBefore = Process.GetCurrentProcess().WorkingSet64;
        await _repository.UpdateAsync(entity);
        var memAfter = Process.GetCurrentProcess().WorkingSet64;

        TestDatum testDatum = new TestDatum
        {
            Language = "Net Core",
            TestName = "EF Get All Operation",
            Performance = $"{stopwatch.ElapsedMilliseconds} ms",
            MemoryUsage = $"{(memAfter - memBefore) / 1024 / 1024} MB",
            CpuUsage = $"{0} ms",
        };

        await _testDatumRepository.AddAsync(testDatum);
    }
}
