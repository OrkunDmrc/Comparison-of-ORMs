import { Customers } from 'dal/entities/Customers.js';
import { CustomerRepository } from '../../dal/repositories/customerRepository';

export class CustomerService {
  private categoryRepository = new CustomerRepository();

  async getAll() {
    return await this.categoryRepository.getAll();
  }

  async getById(id: string) {
    return await this.categoryRepository.getById(id);
  }

  async create(data: Partial<Customers>) {
    return await this.categoryRepository.create(data);
  }

  async update(id: string, data: Partial<Customers>) {
    return await this.categoryRepository.update(id, data);
  }

  async delete(id: string) {
    return await this.categoryRepository.delete(id);
  }
}
