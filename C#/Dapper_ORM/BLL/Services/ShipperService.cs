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

    public Shipper Add(Shipper entity) => _repository.Add(entity);

    public Shipper? Delete(int id) => _repository.Delete(id);

    public List<Shipper> GetAll() => _repository.GetAll();

    public Shipper? GetById(int id) => _repository.GetById(id);

    public Shipper Update(Shipper entity) => _repository.Update(entity);
}
