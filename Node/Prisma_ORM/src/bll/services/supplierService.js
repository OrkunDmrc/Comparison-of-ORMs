const SupplierRepository = require('../../dal/repositories/supplierRepository');

const SupplierService = {
  getAll: async () => {
    return await SupplierRepository.getAll();
  },

  getById: async (id) => {
    const entity = await SupplierRepository.getById(id);
    if (!entity) throw new Error('entity not found');
    return entity;
  },

  create: async (entity) => {
    return await SupplierRepository.create(entity);
  },

  update: async (id, entity) => {
    return await SupplierRepository.update(id, entity);
  },

  delete: async (id) => {
    return await SupplierRepository.delete(id);
  }
};

module.exports = SupplierService; 