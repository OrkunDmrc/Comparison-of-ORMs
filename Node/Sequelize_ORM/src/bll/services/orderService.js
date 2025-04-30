const { performance } = require('perf_hooks');
const process = require('process');
const OrderRepository = require('../../dal/repositories/orderRepository');
const TestDatumRepository = require('../../dal/repositories/testDatumRepository');

class OrderService {
  async getAll() {
    return await OrderRepository.getAll();
  }

  async getById(id) {
    return await OrderRepository.getById(id);
  }

  async create(entity) {
    return await OrderRepository.create(entity);
  }

  async update(id, entity) {
    await OrderRepository.update(id, entity);
  }

  async delete(id) {
    await OrderRepository.delete(id);
  }

  async allTables() {
    await OrderRepository.allTables();
  }
}

module.exports = new OrderService(); 