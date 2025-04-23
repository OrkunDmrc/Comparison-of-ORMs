const RegionRepository = require('../../dal/repositories/regionRepository');

class RegionService {
  async getAll() {
    return await RegionRepository.getAll();
  }

  async getById(id) {
    return await RegionRepository.getById(id);
  }

  async create(data) {
    return await RegionRepository.create(data);
  }

  async update(id, data) {
    return await RegionRepository.update(id, data);
  }

  async delete(id) {
    return await RegionRepository.delete(id);
  }
}

module.exports = new RegionService(); 