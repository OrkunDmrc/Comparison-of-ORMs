import { SupplierRepository } from '../../dal/repositories/supplierRepository';
import { Suppliers } from '../../dal/entities/Suppliers.js';

export class SupplierService {
  private supplierRepository = new SupplierRepository();
  async getAll() {
    return await this.supplierRepository.getAll();
  }

  async getById(id: number) {
    return await this.supplierRepository.getById(id);
  }

  async create(data: Partial<Suppliers>) {
    return await this.supplierRepository.create(data);
  }

  async update(id: number, data: Partial<Suppliers>) {
    return await this.supplierRepository.update(id, data);
  }

  async delete(id: number) {
    return await this.supplierRepository.delete(id);
  }
}