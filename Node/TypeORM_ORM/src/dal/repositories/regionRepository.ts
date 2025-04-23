import { AppDataSource } from '../../config/data-source';
import { Region } from '../entities/Region';
import { GenericRepository } from './genericRepositroy';

export class RegionRepository extends GenericRepository<Region, number> {
  private static repo = AppDataSource.getRepository(Region);
  constructor() {
    super(RegionRepository.repo, 'regionId');
  }
}
