using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories;
using System.Diagnostics;

namespace BLL.Services;

public class OrderService /*: IService<Order, int>*/
{
    private readonly OrderRepository _repository;
    private readonly TestDatumRepository _testDatumRepository;

    public OrderService(OrderRepository repository, TestDatumRepository testDatumRepository)
    {
        _repository = repository;
        _testDatumRepository = testDatumRepository;
    }

    public async Task<Order> AddAsync(Order entity) => await _repository.AddAsync(entity);
    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

    public async Task<List<Order>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Order?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task UpdateAsync(Order entity) => await _repository.UpdateAsync(entity);
}
