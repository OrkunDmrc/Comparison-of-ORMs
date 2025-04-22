const TerritoryRepository = require('../../dal/repositories/territoryRepository');

const TerritoryService = {
  getAll: async () => {
    return await TerritoryRepository.getAll();
  },

  getById: async (id) => {
    const entity = await TerritoryRepository.getById(id);
    if (!entity) throw new Error('entity not found');
    return entity;
  },

  create: async (entity) => {
    return await TerritoryRepository.create(entity);
  },

  update: async (id, entity) => {
    return await TerritoryRepository.update(id, entity);
  },

  delete: async (id) => {
    return await TerritoryRepository.delete(id);
  }
};

module.exports = TerritoryService; 