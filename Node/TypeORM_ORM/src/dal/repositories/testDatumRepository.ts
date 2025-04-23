import { AppDataSource } from '../../config/data-source';
import { TestData } from '../entities/TestData';
import { GenericRepository } from './genericRepositroy';

export class TestDatumRepository extends GenericRepository<TestData, number> {
  private static repo = AppDataSource.getRepository(TestData);
  constructor() {
    super(TestDatumRepository.repo, 'id');
  }
}
