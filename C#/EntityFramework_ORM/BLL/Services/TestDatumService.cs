using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
    public class TestDatumService : IService<TestDatum, int>
    {
        private readonly TestDatumRepository _repository;

        public TestDatumService(TestDatumRepository repository)
        {
            _repository = repository;
        }

        public TestDatum Add(TestDatum entity)
        {
            return _repository.Add(entity);
        }

        public TestDatum? Delete(int id)
        {
            throw new NotImplementedException();
        }

        public  List<TestDatum> GetAll()
        {
            return _repository.GetAll();
        }

        public TestDatum? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TestDatum Update(TestDatum entity)
        {
            throw new NotImplementedException();
        }
    }
}
