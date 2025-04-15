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

    public async Task<Product> AddAsync(Product entity) => await _repository.AddAsync(entity);

    public async Task<Product?> DeleteAsync(int id) => await _repository.DeleteAsync(id);

    public async Task<List<Product>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Product?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<Product> UpdateAsync(Product entity) => await _repository.UpdateAsync(entity);
}
