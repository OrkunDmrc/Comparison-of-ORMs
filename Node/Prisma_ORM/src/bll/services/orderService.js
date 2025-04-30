const OrderRepository = require('../../dal/repositories/orderRepository');

const OrderService = {
  getAll: async () => await OrderRepository.getAll(),

  getById: async (id) => await OrderRepository.getById(id),

  create: async (entity) => await OrderRepository.create(entity),

  update: async (id, entity) => await OrderRepository.update(id, entity),

  delete: async (id) => await OrderRepository.delete(id),

  allTables: async () => await OrderRepository.allTables()
};

module.exports = OrderService; 