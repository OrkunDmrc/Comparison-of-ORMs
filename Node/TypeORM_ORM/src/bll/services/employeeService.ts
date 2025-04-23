import { Employees } from "dal/entities/Employees";
import { EmployeeRepository } from '../../dal/repositories/employeeRepository';

export class EmployeeService {
  private employeeRepository = new EmployeeRepository();

  async getAll() {
    return await this.employeeRepository.getAll();
  }

  async getById(id: number) {
    return await this.employeeRepository.getById(id);
  }

  async create(data: Partial<Employees>) {
    return await this.employeeRepository.create(data);
  }

  async update(id: number, data: Partial<Employees>) {
    return await this.employeeRepository.update(id, data);
  }

  async delete(id: number) {
    return await this.employeeRepository.delete(id);
  }
}
