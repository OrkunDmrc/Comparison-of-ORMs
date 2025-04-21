

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

    public Order_Detail Add(Order_Detail entity) => _repository.Add(entity);

    public Order_Detail? Delete(int orderId, int productId) => _repository.Delete(orderId, productId);

    public List<Order_Detail> GetAll() => _repository.GetAll();

    public Order_Detail? GetById(int orderId, int productId) => _repository.GetById(orderId, productId);

}
