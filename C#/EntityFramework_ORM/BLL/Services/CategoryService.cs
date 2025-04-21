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

    public Category Add(Category entity) => _repository.Add(entity);
    
    public Category? Delete(int id) => _repository.Delete(id);

    public List<Category> GetAll() => _repository.GetAll();

    public Category? GetById(int id) => _repository.GetById(id);

    public Category Update(Category entity) => _repository.Update(entity);
}
