const EmployeeRepository = require('../../dal/repositories/employeeRepository');

const EmployeeService = {
  getAll: async () => {
    return await EmployeeRepository.getAll();
  },

  getById: async (id) => {
    const entity = await EmployeeRepository.getById(id);
    if (!entity) throw new Error('entity not found');
    return entity;
  },

  create: async (entity) => {
    return await EmployeeRepository.create(entity);
  },

  update: async (id, entity) => {
    return await EmployeeRepository.update(id, entity);
  },

  delete: async (id) => {
    return await EmployeeRepository.delete(id);
  }
};

module.exports = EmployeeService; 