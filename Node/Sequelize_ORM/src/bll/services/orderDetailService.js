const OrderDetailRepository = require('../../dal/repositories/orderDetailRepository');

class OrderDetailService {
  async getAll() {
    return await OrderDetailRepository.getAll();
  }

  async getById(orderID, productID) {
    return await OrderDetailRepository.getById(orderID, productID);
  }

  async create(data) {
    return await OrderDetailRepository.create(data);
  }

  async delete(orderID, productID) {
    return await OrderDetailRepository.delete(orderID, productID);
  }
}

module.exports = new OrderDetailService(); 