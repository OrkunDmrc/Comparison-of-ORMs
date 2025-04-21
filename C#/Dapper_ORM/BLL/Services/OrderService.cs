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

    public Order Add(Order entity)
    {
        TestDatum testDatum = new TestDatum();

        var procBefore = Process.GetCurrentProcess();
        var cpuBefore = procBefore.TotalProcessorTime;
        var memBefore = procBefore.WorkingSet64;
        var stopwatch = Stopwatch.StartNew();

        _repository.Add(entity);

        stopwatch.Stop();
        var procAfter = Process.GetCurrentProcess();
        var cpuAfter = procAfter.TotalProcessorTime;
        var memAfter = procAfter.WorkingSet64;

        testDatum.Language = "Net Core";
        testDatum.TestName = "Dapper Create Operation";
        testDatum.Performance = $"{stopwatch.ElapsedMilliseconds} ms";
        testDatum.MemoryUsage = $"{(memAfter - memBefore) / 1024 / 1024} MB";
        testDatum.CpuUsage = $"{(cpuAfter - cpuBefore).TotalMilliseconds} ms";

        _testDatumRepository.Add(testDatum);
        return entity;

    }

    public Order? Delete(int id)
    {
        TestDatum testDatum = new TestDatum();
        var procBefore = Process.GetCurrentProcess();
        var cpuBefore = procBefore.TotalProcessorTime;
        var memBefore = procBefore.WorkingSet64;
        var stopwatch = Stopwatch.StartNew();

        var entity = _repository.Delete(id);

        stopwatch.Stop();
        var procAfter = Process.GetCurrentProcess();
        var cpuAfter = procAfter.TotalProcessorTime;
        var memAfter = procAfter.WorkingSet64;

        testDatum.Language = "Net Core";
        testDatum.TestName = "Dapper Remove Operation";
        testDatum.Performance = $"{stopwatch.ElapsedMilliseconds} ms";
        testDatum.MemoryUsage = $"{(memAfter - memBefore) / 1024 / 1024} MB";
        testDatum.CpuUsage = $"{(cpuAfter - cpuBefore).TotalMilliseconds} ms";

        _testDatumRepository.Add(testDatum);

        return entity;
    }

    public List<Order> GetAll()
    {
        TestDatum testDatum = new TestDatum();
        var procBefore = Process.GetCurrentProcess();
        var cpuBefore = procBefore.TotalProcessorTime;
        var memBefore = procBefore.WorkingSet64;
        var stopwatch = Stopwatch.StartNew();

        var entities = _repository.GetAll();

        stopwatch.Stop();
        var procAfter = Process.GetCurrentProcess();
        var cpuAfter = procAfter.TotalProcessorTime;
        var memAfter = procAfter.WorkingSet64;

        testDatum.Language = "Net Core";
        testDatum.TestName = "Dapper Get All Operation";
        testDatum.Performance = $"{stopwatch.ElapsedMilliseconds} ms";
        testDatum.MemoryUsage = $"{(memAfter - memBefore) / 1024 / 1024} MB";
        testDatum.CpuUsage = $"{(cpuAfter - cpuBefore).TotalMilliseconds} ms";

        _testDatumRepository.Add(testDatum);

        return entities;
    }

    public Order? GetById(int id)
    {
        TestDatum testDatum = new TestDatum();
        var procBefore = Process.GetCurrentProcess();
        var cpuBefore = procBefore.TotalProcessorTime;
        var memBefore = procBefore.WorkingSet64;
        var stopwatch = Stopwatch.StartNew();

        var entity = _repository.GetById(id);

        stopwatch.Stop();
        var procAfter = Process.GetCurrentProcess();
        var cpuAfter = procAfter.TotalProcessorTime;
        var memAfter = procAfter.WorkingSet64;

        testDatum.Language = "Net Core";
        testDatum.TestName = "Dapper Get By Id Operation";
        testDatum.Performance = $"{stopwatch.ElapsedMilliseconds} ms";
        testDatum.MemoryUsage = $"{(memAfter - memBefore) / 1024 / 1024} MB";
        testDatum.CpuUsage = $"{(cpuAfter - cpuBefore).TotalMilliseconds} ms";

        _testDatumRepository.Add(testDatum);

        return entity;
    }

    public Order Update(Order entity)
    {
        TestDatum testDatum = new TestDatum();
        var procBefore = Process.GetCurrentProcess();
        var cpuBefore = procBefore.TotalProcessorTime;
        var memBefore = procBefore.WorkingSet64;
        var stopwatch = Stopwatch.StartNew();

        _repository.Update(entity);

        stopwatch.Stop();
        var procAfter = Process.GetCurrentProcess();
        var cpuAfter = procAfter.TotalProcessorTime;
        var memAfter = procAfter.WorkingSet64;

        testDatum.Language = "Net Core";
        testDatum.TestName = "Dapper Update Operation";
        testDatum.Performance = $"{stopwatch.ElapsedMilliseconds} ms";
        testDatum.MemoryUsage = $"{(memAfter - memBefore) / 1024 / 1024} MB";
        testDatum.CpuUsage = $"{(cpuAfter - cpuBefore).TotalMilliseconds} ms";

        _testDatumRepository.Add(testDatum);

        return entity;
    }
}
