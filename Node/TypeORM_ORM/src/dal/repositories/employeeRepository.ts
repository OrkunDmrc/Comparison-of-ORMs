import { AppDataSource } from '../../config/data-source';
import { Employees } from '../entities/Employees';
import { GenericRepository } from './genericRepositroy';

export class EmployeeRepository extends GenericRepository<Employees, number> {
  private static repo = AppDataSource.getRepository(Employees);
  constructor() {
    super(EmployeeRepository.repo, 'employeeId');
  }
}
