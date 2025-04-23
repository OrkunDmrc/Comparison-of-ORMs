const CategoryRepository = require('../../dal/repositories/categoryRepository');

class CategoryService {
  async getAll() {
    return await CategoryRepository.getAll();
  }

  async getById(id) {
    return await CategoryRepository.getById(id);
  }

  async create(data) {
    return await CategoryRepository.create(data);
  }

  async update(id, data) {
    return await CategoryRepository.update(id, data);
  }

  async delete(id) {
    return await CategoryRepository.delete(id);
  }
}

module.exports = new CategoryService();