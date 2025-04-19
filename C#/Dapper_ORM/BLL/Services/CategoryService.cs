using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class CategoryService : IService<Category, int>
{
    private readonly CategoryRepository _repository;

    public CategoryService(CategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Category> AddAsync(Category entity) => await _repository.AddAsync(entity);
    
    public async Task<Category?> DeleteAsync(int id) => await _repository.DeleteAsync(id);

    public async Task<List<Category>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Category?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<Category> UpdateAsync(Category entity) => await _repository.UpdateAsync(entity, entity.CategoryID);
}
