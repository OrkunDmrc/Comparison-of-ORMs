const CustomerRepository = require('../../dal/repositories/customerRepository');

const CustomerService = {
  getAll: async () => {
    return await CustomerRepository.getAll();
  },

  getById: async (id) => {
    const entity = await CustomerRepository.getById(id);
    if (!entity) throw new Error('entity not found');
    return entity;
  },

  create: async (entity) => {
    return await CustomerRepository.create(entity);
  },

  update: async (id, entity) => {
    return await CustomerRepository.update(id, entity);
  },

  delete: async (id) => {
    return await CustomerRepository.delete(id);
  }
};

module.exports = CustomerService; 