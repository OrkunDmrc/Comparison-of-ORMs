using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class ShipperService : IService<Shipper, int>
{
    private readonly ShipperRepository _repository;

    public ShipperService(ShipperRepository repository)
    {
        _repository = repository;
    }

    public async Task<Shipper> AddAsync(Shipper entity) => await _repository.AddAsync(entity);

    public async Task<Shipper?> DeleteAsync(int id) => await _repository.DeleteAsync(id);

    public async Task<List<Shipper>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Shipper?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<Shipper> UpdateAsync(Shipper entity) => await _repository.UpdateAsync(entity, entity.ShipperID);
}
