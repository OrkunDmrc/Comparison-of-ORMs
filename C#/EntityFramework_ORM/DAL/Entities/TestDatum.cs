using DAL.Interfaces;

namespace DAL.Entities;

public partial class TestDatum : IEntity
{
    public int Id { get; set; }

    public string Language { get; set; } = null!;

    public string TestName { get; set; } = null!;

    public string Performance { get; set; } = null!;

    public string MemoryUsage { get; set; } = null!;

    public string CpuUsage { get; set; } = null!;
}
