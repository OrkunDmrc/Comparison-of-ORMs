

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

    public async Task<Order_Detail> AddAsync(Order_Detail entity) => await _repository.AddAsync(entity);

    public async Task<Order_Detail?> DeleteAsync(int orderId, int productId) => await _repository.DeleteAsync(orderId, productId);

    public async Task<List<Order_Detail>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Order_Detail?> GetByIdAsync(int orderId, int productId) => await _repository.GetByIdAsync(orderId, productId);

}
