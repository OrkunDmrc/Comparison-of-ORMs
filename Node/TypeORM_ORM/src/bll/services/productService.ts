import { Products } from 'dal/entities/Products';
import { ProductRepository } from '../../dal/repositories/productRepository';

export class ProductService {
  private productRepository = new ProductRepository();
  async getAll() {
    return await this.productRepository.getAll();
  }

  async getById(id: number) {
    return await this.productRepository.getById(id);
  }

  async create(data: Partial<Products>) {
    return await this.productRepository.create(data);
  }

  async update(id: number, data: Partial<Products>) {
    return await this.productRepository.update(id, data);
  }

  async delete(id: number) {
    return await this.productRepository.delete(id);
  }
}
