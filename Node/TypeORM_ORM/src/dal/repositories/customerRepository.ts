import { AppDataSource } from '../../config/data-source';
import { Customers } from '../entities/Customers';
import { GenericRepository } from './genericRepositroy';

export class CustomerRepository extends GenericRepository<Customers, string> {
  private static repo = AppDataSource.getRepository(Customers);
  constructor() {
    super(CustomerRepository.repo, 'customerId');
  }
}
