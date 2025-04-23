const EmployeeTerritoryRepository = require('../../dal/repositories/employeeTerritoryRepository');

class EmployeeTerritoryService {
  async getAll() {
    return await EmployeeTerritoryRepository.getAll();
  }

  async getById(id) {
    return await EmployeeTerritoryRepository.getById(id);
  }

  async create(data) {
    return await EmployeeTerritoryRepository.create(data);
  }

  async update(id, data) {
    return await EmployeeTerritoryRepository.update(id, data);
  }

  async delete(id) {
    return await EmployeeTerritoryRepository.delete(id);
  }
}

module.exports = new EmployeeTerritoryService(); 