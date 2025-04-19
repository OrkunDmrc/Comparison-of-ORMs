using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class EmployeeService : IService<Employee, int>
{
    private readonly EmployeeRepository _repository;

    public EmployeeService(EmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Employee> AddAsync(Employee entity) => await _repository.AddAsync(entity);

    public async Task<Employee?> DeleteAsync(int id) => await _repository.DeleteAsync(id);

    public async Task<List<Employee>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Employee?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<Employee> UpdateAsync(Employee entity) => await _repository.UpdateAsync(entity);
}
