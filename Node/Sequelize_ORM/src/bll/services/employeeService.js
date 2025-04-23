const EmployeeRepository = require('../../dal/repositories/employeeRepository');

class EmployeeService {
  async getAll() {
    return await EmployeeRepository.getAll();
  }

  async getById(id) {
    return await EmployeeRepository.getById(id);
  }

  async create(data) {
    return await EmployeeRepository.create(data);
  }

  async update(id, data) {
    return await EmployeeRepository.update(id, data);
  }

  async delete(id) {
    return await EmployeeRepository.delete(id);
  }
}

module.exports = new EmployeeService(); 