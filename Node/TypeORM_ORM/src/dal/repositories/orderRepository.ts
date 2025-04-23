import { AppDataSource } from '../../config/data-source';
import { Orders } from '../entities/Orders';
import { GenericRepository } from './genericRepositroy';

export class OrderRepository extends GenericRepository<Orders, number> {
  private static repo = AppDataSource.getRepository(Orders);
  constructor() {
    super(OrderRepository.repo, 'orderId');
  }
}
