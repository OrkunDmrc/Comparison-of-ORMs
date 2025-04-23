const CategoryRepository = require('../../dal/repositories/categoryRepository');

const CategoryService = {
  getAll: async () => {
    return await CategoryRepository.getAll();
  },

  getById: async (id) => {
    const entity = await CategoryRepository.getById(id);
    if (!entity) throw new Error('entity not found');
    return entity;
  },

  create: async (entity) => {
    return await CategoryRepository.create(entity);
  },

  update: async (id, entity) => {
    return await CategoryRepository.update(id, entity);
  },

  delete: async (id) => {
    return await CategoryRepository.delete(id);
  }
};

module.exports = CategoryService;