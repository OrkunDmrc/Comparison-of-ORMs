import { AppDataSource } from '../../config/data-source';
import { Territories } from '../entities/Territories';
import { GenericRepository } from './genericRepositroy';

export class TerritoryRepository extends GenericRepository<Territories, string> {
  private static repo = AppDataSource.getRepository(Territories);
  constructor() {
    super(TerritoryRepository.repo, 'territoryId');
  }
}
