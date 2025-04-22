const EmployeeTerritoryRepository = require('../../dal/repositories/employeeTerritoryRepository');

const EmployeeTerritoryService = {
  getAll: async () => {
    return await EmployeeTerritoryRepository.getAll();
  },

  getById: async (id) => {
    const entity = await EmployeeTerritoryRepository.getById(id);
    if (!entity) throw new Error('entity not found');
    return entity;
  },

  create: async (entity) => {
    return await EmployeeTerritoryRepository.create(entity);
  },

  update: async (id, entity) => {
    return await EmployeeTerritoryRepository.update(id, entity);
  },

  delete: async (id) => {
    return await EmployeeTerritoryRepository.delete(id);
  }
};

module.exports = EmployeeTerritoryService; 