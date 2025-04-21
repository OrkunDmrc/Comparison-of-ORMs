using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class RegionService : IService<Region, int>
{
    private readonly RegionRepository _repository;

    public RegionService(RegionRepository repository)
    {
        _repository = repository;
    }

    public Region Add(Region entity) => _repository.Add(entity);

    public Region? Delete(int id) => _repository.Delete(id);

    public List<Region> GetAll() => _repository.GetAll();

    public Region? GetById(int id) => _repository.GetById(id);

    public Region Update(Region entity) => _repository.Update(entity);
}
