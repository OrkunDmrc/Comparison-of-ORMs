const ShipperRepository = require('../../dal/repositories/shipperRepository');

class ShipperService {
  async getAll() {
    return await ShipperRepository.getAll();
  }

  async getById(id) {
    return await ShipperRepository.getById(id);
  }

  async create(data) {
    return await ShipperRepository.create(data);
  }

  async update(id, data) {
    return await ShipperRepository.update(id, data);
  }

  async delete(id) {
    return await ShipperRepository.delete(id);
  }
}

module.exports = new ShipperService(); 