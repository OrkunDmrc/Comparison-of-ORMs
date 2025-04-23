const TerritoryRepository = require('../../dal/repositories/territoryRepository');

class TerritoryService {
  async getAll() {
    return await TerritoryRepository.getAll();
  }

  async getById(id) {
    return await TerritoryRepository.getById(id);
  }

  async create(data) {
    return await TerritoryRepository.create(data);
  }

  async update(id, data) {
    return await TerritoryRepository.update(id, data);
  }

  async delete(id) {
    return await TerritoryRepository.delete(id);
  }
}

module.exports = new TerritoryService(); 