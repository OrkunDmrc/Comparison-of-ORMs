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

    public Employee Add(Employee entity) => _repository.Add(entity);

    public Employee? Delete(int id) => _repository.Delete(id);

    public List<Employee> GetAll() => _repository.GetAll();

    public Employee? GetById(int id) => _repository.GetById(id);

    public Employee Update(Employee entity) => _repository.Update(entity);
}
