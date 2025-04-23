import { AppDataSource } from '../../config/data-source';
import { Suppliers } from '../entities/Suppliers';
import { GenericRepository } from './genericRepositroy';

export class SupplierRepository extends GenericRepository<Suppliers, number> {
  private static repo = AppDataSource.getRepository(Suppliers);
  constructor() {
    super(SupplierRepository.repo, 'supplierId');
  }
}
