const TestDatumRepository = require('../../dal/repositories/testDatumRepository');

const TestDatumService = {
  getAll: async () => {
    return await TestDatumRepository.getAll();
  },

  getById: async (id) => {
    const entity = await TestDatumRepository.getById(id);
    if (!entity) throw new Error('entity not found');
    return entity;
  },

  create: async (entity) => {
    return await TestDatumRepository.create(entity);
  },

  update: async (id, entity) => {
    return await TestDatumRepository.update(id, entity);
  },

  delete: async (id) => {
    return await TestDatumRepository.delete(id);
  }
};

module.exports = TestDatumService; 