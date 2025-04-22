const ShipperRepository = require('../../dal/repositories/shipperRepository');

const ShipperService = {
  getAll: async () => {
    return await ShipperRepository.getAll();
  },

  getById: async (id) => {
    const entity = await ShipperRepository.getById(id);
    if (!entity) throw new Error('entity not found');
    return entity;
  },

  create: async (entity) => {
    return await ShipperRepository.create(entity);
  },

  update: async (id, entity) => {
    return await ShipperRepository.update(id, entity);
  },

  delete: async (id) => {
    return await ShipperRepository.delete(id);
  }
};

module.exports = ShipperService; 