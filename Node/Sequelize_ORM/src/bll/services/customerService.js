const CustomerRepository = require('../../dal/repositories/customerRepository.js');

class CustomerService {
  async getAll() {
    return await CustomerRepository.getAll();
  }

  async getById(id) {
    return await CustomerRepository.getById(id);
  }

  async create(data) {
    return await CustomerRepository.create(data);
  }

  async update(id, data) {
    return await CustomerRepository.update(id, data);
  }

  async delete(id) {
    return await CustomerRepository.delete(id);
  }
}

module.exports = new CustomerService(); 