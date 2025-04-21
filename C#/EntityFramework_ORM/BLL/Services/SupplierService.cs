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

    public Supplier Add(Supplier entity) => _repository.Add(entity);

    public Supplier? Delete(int id) => _repository.Delete(id);

    public List<Supplier> GetAll() => _repository.GetAll();

    public Supplier? GetById(int id) => _repository.GetById(id);

    public Supplier Update(Supplier entity) => _repository.Update(entity);
}
