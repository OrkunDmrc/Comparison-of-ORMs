using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories;

namespace MyApp.BLL.Services;

public class RegionService : IService<Region, int>
{
    private readonly RegionRepository _repository;

    public RegionService(RegionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Region> AddAsync(Region entity) => await _repository.AddAsync(entity);

    public async Task<Region?> DeleteAsync(int id) => await _repository.DeleteAsync(id);

    public async Task<List<Region>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Region?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<Region> UpdateAsync(Region entity) => await _repository.UpdateAsync(entity);
}
