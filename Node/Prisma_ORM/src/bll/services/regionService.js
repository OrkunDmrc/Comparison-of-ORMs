const RegionRepository = require('../../dal/repositories/regionRepository');

const RegionService = {
  getAll: async () => {
    return await RegionRepository.getAll();
  },

  getById: async (id) => {
    const entity = await RegionRepository.getById(id);
    if (!entity) throw new Error('entity not found');
    return entity;
  },

  create: async (entity) => {
    return await RegionRepository.create(entity);
  },

  update: async (id, entity) => {
    return await RegionRepository.update(id, entity);
  },

  delete: async (id) => {
    return await RegionRepository.delete(id);
  }
};

module.exports = RegionService; 