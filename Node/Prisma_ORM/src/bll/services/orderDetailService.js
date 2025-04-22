const OrderDetailRepository = require('../../dal/repositories/orderDetailRepository');

const OrderDetailService = {
  getAll: async () => {
    return await OrderDetailRepository.getAll();
  },

  getById: async (orderID, productID) => {
    const entity = await OrderDetailRepository.getById(orderID, productID);
    if (!entity) throw new Error('entity not found');
    return entity;
  },

  create: async (entity) => {
    return await OrderDetailRepository.create(entity);
  },

  delete: async (orderID, productID) => {
    return await OrderDetailRepository.delete(orderID, productID);
  }
};

module.exports = OrderDetailService; 