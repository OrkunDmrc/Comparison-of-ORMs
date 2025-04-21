using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class ProductService : IService<Product, int>
{
    private readonly ProductRepository _repository;

    public ProductService(ProductRepository repository)
    {
        _repository = repository;
    }

    public Product Add(Product entity) => _repository.Add(entity);

    public Product? Delete(int id) => _repository.Delete(id);

    public List<Product> GetAll() => _repository.GetAll();

    public Product? GetById(int id) => _repository.GetById(id);

    public Product Update(Product entity) => _repository.Update(entity);
}
