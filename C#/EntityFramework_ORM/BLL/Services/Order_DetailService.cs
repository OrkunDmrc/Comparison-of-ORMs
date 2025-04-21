

using BLL.Interfaces;
using DAL.Entities;

namespace DAL.Repositories;

public class Order_DetailService
{
    private readonly Order_DetailRepository _repository;

    public Order_DetailService(Order_DetailRepository repository)
    {
        _repository = repository;
    }

    public async Task<Order_Detail?> Add(Order_Detail entity) => _repository.Add(entity);

    public async Task<Order_Detail?> Delete(int orderId, int productId) => await _repository.DeleteAsync(orderId, productId);

    public async Task<List<Order_Detail>> GetAllAsync() => await _repository.GetAll();

    public async Task<Order_Detail?> GetByIdAsync(int orderId, int productId) => await _repository.GetByIdAsync(orderId, productId);

}
