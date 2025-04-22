const ProductRepository = require('../../dal/repositories/productRepository');

const ProductService = {
  getAll: async () => {
    return await ProductRepository.getAll();
  },

  getById: async (id) => {
    const entity = await ProductRepository.getById(id);
    if (!entity) throw new Error('entity not found');
    return entity;
  },

  create: async (entity) => {
    return await ProductRepository.create(entity);
  },

  update: async (id, entity) => {
    return await ProductRepository.update(id, entity);
  },

  delete: async (id) => {
    return await ProductRepository.delete(id);
  }
};

module.exports = ProductService; 