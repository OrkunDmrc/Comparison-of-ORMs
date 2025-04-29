using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
    public class TestDatumService /*: IService<TestDatum, int>*/
    {
        private readonly TestDatumRepository _repository;

        public TestDatumService(TestDatumRepository repository)
        {
            _repository = repository;
        }

        public async Task<TestDatum> AddAsync(TestDatum entity)
        {
            return await _repository.AddAsync(entity);
        }

        public Task<TestDatum?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TestDatum>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Task<TestDatum?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TestDatum> UpdateAsync(TestDatum entity)
        {
            throw new NotImplementedException();
        }
    }
}
