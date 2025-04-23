import { AppDataSource } from '../../config/data-source';
import { Products } from '../entities/Products';
import { GenericRepository } from './genericRepositroy';

export class ProductRepository extends GenericRepository<Products, number> {
  private static repo = AppDataSource.getRepository(Products);
  constructor() {
    super(ProductRepository.repo, 'productId');
  }
}
