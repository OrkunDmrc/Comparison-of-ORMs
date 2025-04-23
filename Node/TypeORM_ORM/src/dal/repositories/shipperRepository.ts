import { AppDataSource } from '../../config/data-source';
import { Shippers } from '../entities/Shippers';
import { GenericRepository } from './genericRepositroy';

export class ShipperRepository extends GenericRepository<Shippers, number> {
  private static repo = AppDataSource.getRepository(Shippers);
  constructor() {
    super(ShipperRepository.repo, 'shipperId');
  }
}
