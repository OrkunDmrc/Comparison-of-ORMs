
using DAL.Entities;

namespace DAL.Repositories;

public class TestDatumRepository : GenericRepository<TestDatum, int>
{
    public TestDatumRepository(string connectionString) : base(connectionString, "TestData", "Id")
    {
    }
}

