using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class CustomerService /*: IService<Customer, string>*/
{
    private readonly CustomerRepository _repository;

    public CustomerService(CustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer> AddAsync(Customer entity) => await _repository.AddAsync(entity);

    public async Task DeleteAsync(string id) => await _repository.DeleteAsync(id);

    public async Task<List<Customer>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Customer?> GetByIdAsync(string id) => await _repository.GetByIdAsync(id);

    public async Task UpdateAsync(Customer entity) => await _repository.UpdateAsync(entity);
}
