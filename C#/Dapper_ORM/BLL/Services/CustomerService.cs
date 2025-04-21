using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class CustomerService : IService<Customer, string>
{
    private readonly CustomerRepository _repository;

    public CustomerService(CustomerRepository repository)
    {
        _repository = repository;
    }

    public Customer Add(Customer entity) => _repository.Add(entity);

    public Customer? Delete(string id) => _repository.Delete(id);

    public List<Customer> GetAll() => _repository.GetAll();

    public Customer? GetById(string id) => _repository.GetById(id);

    public Customer Update(Customer entity) => _repository.Update(entity);
}
