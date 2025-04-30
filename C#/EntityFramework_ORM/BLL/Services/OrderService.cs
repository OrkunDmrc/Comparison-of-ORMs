using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class OrderService /*: IService<Order, int>*/
{
    private readonly OrderRepository _repository;

    public OrderService(OrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Order> AddAsync(Order entity) => await _repository.AddAsync(entity);

    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

    public async Task<List<Order>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Order?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task UpdateAsync(Order entity) => await _repository.UpdateAsync(entity);

    public async Task AllTablesTestAsync() => await _repository.AllTablesTestAsync();
}
