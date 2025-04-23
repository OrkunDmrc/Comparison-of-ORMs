import { TestData } from '../../dal/entities/TestData';
import { TestDatumRepository } from '../../dal/repositories/testDatumRepository';

export class TestDatumService {
  private testDatumRepository = new TestDatumRepository();
  async getAll() {
    return await this.testDatumRepository.getAll();
  }

  async getById(id: number) {
    return await this.testDatumRepository.getById(id);
  }

  async create(data: Partial<TestData>) {
    return await this.testDatumRepository.create(data);
  }

  async update(id: number, data: Partial<TestData>) {
    return await this.testDatumRepository.update(id, data);
  }

  async delete(id: number) {
    return await this.testDatumRepository.delete(id);
  }
}