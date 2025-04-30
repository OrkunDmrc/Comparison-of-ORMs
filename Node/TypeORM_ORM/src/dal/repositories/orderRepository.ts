import { AppDataSource } from '../../config/data-source';
import { Orders } from '../entities/Orders';
//import { GenericRepository } from './genericRepositroy';

export class OrderRepository/* extends GenericRepository<Orders, number>*/ {
    private repo;
    constructor() {
      this.repo = AppDataSource.getRepository(Orders);;
    }

    async getAll() {
      return this.repo.find();
    }
  
    async getById(id: number) {
      return this.repo.findOneBy({ ["OrderID"]: id } as any);
    }
  
    async create(data: Partial<Orders>) {
      const entity = this.repo.create(data);
      return this.repo.save(entity);
    }
  
    async update(id: number, updateData: Partial<Orders>) {
      const entity = await this.getById(id);
      if (!entity) return null;
      this.repo.merge(entity, updateData);
      return this.repo.save(entity);
    }
  
    async delete(id: number) {
      const result = await this.repo.delete(id);
      return result.affected !== 0;
    }
}
