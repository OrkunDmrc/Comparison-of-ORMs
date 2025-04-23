const TestDatumRepository = require('../../dal/repositories/testDatumRepository');

class TestDatumService {
  async getAll() {
    return await TestDatumRepository.getAll();
  }

  async getById(id) {
    return await TestDatumRepository.getById(id);
  }

  async create(data) {
    return await TestDatumRepository.create(data);
  }

  async update(id, data) {
    return await TestDatumRepository.update(id, data);
  }

  async delete(id) {
    return await TestDatumRepository.delete(id);
  }
}

module.exports = new TestDatumService();