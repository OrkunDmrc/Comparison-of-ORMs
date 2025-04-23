const ProductRepository = require('../../dal/repositories/productRepository');

class ProductService {
  async getAll() {
    return await ProductRepository.getAll();
  }

  async getById(id) {
    return await ProductRepository.getById(id);
  }

  async create(data) {
    return await ProductRepository.create(data);
  }

  async update(id, data) {
    return await ProductRepository.update(id, data);
  }

  async delete(id) {
    return await ProductRepository.delete(id);
  }
}

module.exports = new ProductService(); 