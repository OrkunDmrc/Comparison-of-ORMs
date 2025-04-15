

using BLL.Interfaces;
using DAL.Entities;

namespace DAL.Repositories;

public class Order_DetailService : IService<Order_Detail, int>
{
    private readonly Order_DetailRepository _repository;

    public Order_DetailService(Order_DetailRepository repository)
    {
        _repository = repository;
    }

    public async Task<Order_Detail> AddAsync(Order_Detail entity) => await _repository.AddAsync(entity);

    public async Task<Order_Detail?> DeleteAsync(int id) => await _repository.DeleteAsync(id);

    public async Task<List<Order_Detail>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Order_Detail?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<Order_Detail> UpdateAsync(Order_Detail entity) => await _repository.UpdateAsync(entity);
}
