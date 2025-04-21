using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories;
using System.Diagnostics;

namespace BLL.Services;

public class OrderService : IService<Order, int>
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
        var procBefore = Process.GetCurrentProcess();
        var cpuBefore = procBefore.TotalProcessorTime;
        var memBefore = procBefore.WorkingSet64;
        var stopwatch = Stopwatch.StartNew();

        await _repository.AddAsync(entity);

        stopwatch.Stop();
        var procAfter = Process.GetCurrentProcess();
        var cpuAfter = procAfter.TotalProcessorTime;
        var memAfter = procAfter.WorkingSet64;

        TestDatum testDatum = new TestDatum
        {
            Language = "Net Core",
            TestName = "EF Get All Operation",
            Performance = $"{stopwatch.ElapsedMilliseconds} ms",
            MemoryUsage = $"{(memAfter - memBefore) / 1024 / 1024} MB",
            CpuUsage = $"{(cpuAfter - cpuBefore).TotalMilliseconds} ms",
        };

        await _testDatumRepository.AddAsync(testDatum);
        return entity;

    }

    public async Task<Order?> DeleteAsync(int id)
    {
        var procBefore = Process.GetCurrentProcess();
        var cpuBefore = procBefore.TotalProcessorTime;
        var memBefore = procBefore.WorkingSet64;
        var stopwatch = Stopwatch.StartNew();

        var entity = await _repository.DeleteAsync(id);

        stopwatch.Stop();
        var procAfter = Process.GetCurrentProcess();
        var cpuAfter = procAfter.TotalProcessorTime;
        var memAfter = procAfter.WorkingSet64;

        TestDatum testDatum = new TestDatum
        {
            Language = "Net Core",
            TestName = "EF Get All Operation",
            Performance = $"{stopwatch.ElapsedMilliseconds} ms",
            MemoryUsage = $"{(memAfter - memBefore) / 1024 / 1024} MB",
            CpuUsage = $"{(cpuAfter - cpuBefore).TotalMilliseconds} ms",
        };

        await _testDatumRepository.AddAsync(testDatum);

        return entity;
    }

    public async Task<List<Order>> GetAllAsync()
    {

        var procBefore = Process.GetCurrentProcess();
        var cpuBefore = procBefore.TotalProcessorTime;
        var memBefore = procBefore.WorkingSet64;
        var stopwatch = Stopwatch.StartNew();

        var entities = await _repository.GetAllAsync();

        stopwatch.Stop();
        var procAfter = Process.GetCurrentProcess();
        var cpuAfter = procAfter.TotalProcessorTime;
        var memAfter = procAfter.WorkingSet64;

        TestDatum testDatum = new TestDatum
        {
            Language = "Net Core",
            TestName = "EF Get All Operation",
            Performance = $"{stopwatch.ElapsedMilliseconds} ms",
            MemoryUsage = $"{(memAfter - memBefore) / 1024 / 1024} MB",
            CpuUsage = $"{(cpuAfter - cpuBefore).TotalMilliseconds} ms",
        };
        await _testDatumRepository.AddAsync(testDatum);

        return entities;
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        var procBefore = Process.GetCurrentProcess();
        var cpuBefore = procBefore.TotalProcessorTime;
        var memBefore = procBefore.WorkingSet64;
        var stopwatch = Stopwatch.StartNew();

        var entity = await _repository.GetByIdAsync(id);

        stopwatch.Stop();
        var procAfter = Process.GetCurrentProcess();
        var cpuAfter = procAfter.TotalProcessorTime;
        var memAfter = procAfter.WorkingSet64;

        TestDatum testDatum = new TestDatum
        {
            Language = "Net Core",
            TestName = "EF Get Operation",
            Performance = $"{stopwatch.ElapsedMilliseconds} ms",
            MemoryUsage = $"{(memAfter - memBefore) / 1024 / 1024} MB",
            CpuUsage = $"{(cpuAfter - cpuBefore).TotalMilliseconds} ms",
        };

        await _testDatumRepository.AddAsync(testDatum);

        return entity;
    }

    public async Task<Order> UpdateAsync(Order entity)
    {
        var procBefore = Process.GetCurrentProcess();
        var cpuBefore = procBefore.TotalProcessorTime;
        var memBefore = procBefore.WorkingSet64;
        var stopwatch = Stopwatch.StartNew();

        await _repository.UpdateAsync(entity);

        stopwatch.Stop();
        var procAfter = Process.GetCurrentProcess();
        var cpuAfter = procAfter.TotalProcessorTime;
        var memAfter = procAfter.WorkingSet64;

        TestDatum testDatum = new TestDatum
        {
            Language = "Net Core",
            TestName = "EF Get All Operation",
            Performance = $"{stopwatch.ElapsedMilliseconds} ms",
            MemoryUsage = $"{(memAfter - memBefore) / 1024 / 1024} MB",
            CpuUsage = $"{(cpuAfter - cpuBefore).TotalMilliseconds} ms",
        };

        await _testDatumRepository.AddAsync(testDatum);

        return entity;
    }
}
