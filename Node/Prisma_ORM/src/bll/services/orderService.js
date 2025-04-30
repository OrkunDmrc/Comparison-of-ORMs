const { performance } = require('perf_hooks');
const process = require('process');
const OrderRepository = require('../../dal/repositories/orderRepository');
const TestDatumRepository = require('../../dal/repositories/testDatumRepository');

const OrderService = {
  getAll: async () => await OrderRepository.getAll(),

  getById: async (id) => await OrderRepository.getById(id),

  create: async (entity) => await OrderRepository.create(entity),

  update: async (id, entity) => await OrderRepository.update(id, entity),

  delete: async (id) => await OrderRepository.delete(id)
};

module.exports = OrderService; 