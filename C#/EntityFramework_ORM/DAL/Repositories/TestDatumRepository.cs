using DAL.Data;
using DAL.Entities;

namespace DAL.Repositories
{
    public class TestDatumRepository : GenericRepository<TestDatum, int>
    {
        public TestDatumRepository(MyAppDbContext context) : base(context)
        {
        }
    }
}
