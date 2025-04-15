using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class SupplierService : IService<Supplier, int>
{
    private readonly SupplierRepository _repository;

    public SupplierService(SupplierRepository repository)
    {
        _repository = repository;
    }

    public async Task<Supplier> AddAsync(Supplier entity) => await _repository.AddAsync(entity);

    public async Task<Supplier?> DeleteAsync(int id) => await _repository.DeleteAsync(id);

    public async Task<List<Supplier>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Supplier?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<Supplier> UpdateAsync(Supplier entity) => await _repository.UpdateAsync(entity);
}
