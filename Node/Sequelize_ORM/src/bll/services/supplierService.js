const SupplierRepository = require('../../dal/repositories/supplierRepository');

class SupplierService {
  async getAll() {
    return await SupplierRepository.getAll();
  }

  async getById(id) {
    return await SupplierRepository.getById(id);
  }

  async create(data) {
    return await SupplierRepository.create(data);
  }

  async update(id, data) {
    return await SupplierRepository.update(id, data);
  }

  async delete(id) {
    return await SupplierRepository.delete(id);
  }
}

module.exports = new SupplierService(); 