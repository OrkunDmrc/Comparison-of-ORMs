using BLL.Interfaces;
using DAL.Entities;

namespace DAL.Repositories;

public class TerritoryService : IService<Territory, string>
{
    private readonly TerritoryRepository _repository;

    public TerritoryService(TerritoryRepository repository)
    {
        _repository = repository;
    }

    public Territory Add(Territory entity) => _repository.Add(entity);

    public Territory? Delete(string id) => _repository.Delete(id);

    public List<Territory> GetAll() => _repository.GetAll();

    public Territory? GetById(string id) => _repository.GetById(id);

    public Territory Update(Territory entity) => _repository.Update(entity);
}
