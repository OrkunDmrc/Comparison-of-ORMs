import { AppDataSource } from '../../config/data-source';
import { Categories } from '../entities/Categories';
import { GenericRepository } from './genericRepositroy';

export class CategoryRepository extends GenericRepository<Categories, number> {
  private static repo = AppDataSource.getRepository(Categories);
  constructor() {
    super(CategoryRepository.repo, 'categoryId');
  }
}