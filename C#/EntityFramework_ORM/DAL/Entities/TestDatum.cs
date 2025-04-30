using DAL.Interfaces;

namespace DAL.Entities;

public partial class TestDatum : IEntity
{
    public int Id { get; set; }

    public string Language { get; set; }

    public string TestName { get; set; }

    public string Performance { get; set; }

    public string MemoryUsage { get; set; }

    public string CpuUsage { get; set; }
}
