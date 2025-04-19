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

    public async Task<Territory> AddAsync(Territory entity) => await _repository.AddAsync(entity);

    public async Task<Territory?> DeleteAsync(string id) => await _repository.DeleteAsync(id);

    public async Task<List<Territory>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Territory?> GetByIdAsync(string id) => await _repository.GetByIdAsync(id);

    public async Task<Territory> UpdateAsync(Territory entity) => await _repository.UpdateAsync(entity, entity.TerritoryID);
}
