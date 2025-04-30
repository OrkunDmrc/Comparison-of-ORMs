import { AppDataSource } from '../../config/data-source';
import { Orders } from '../entities/Orders';
import { TestDatumRepository } from '../../dal/repositories/testDatumRepository';
import { TestData } from '../../dal/entities/TestData';
import { performance } from 'perf_hooks';

//import { GenericRepository } from './genericRepositroy';

export class OrderRepository/* extends GenericRepository<Orders, number>*/ {
  private repo;
  private testDataRepo; 
  constructor() {
    this.repo = AppDataSource.getRepository(Orders);
    this.testDataRepo = new TestDatumRepository();
  }

  async getAll() {
    const start = performance.now();
    const entities = await this.repo.find();
    const end = performance.now();
    const testDatum = new TestData();
    testDatum.testName = 'Typeorm Get All Operation';
    testDatum.cpuUsage = `${/*(cpuAfter.user / 1000).toFixed(2)*/0} ms`;
    testDatum.memoryUsage = `${/*((memAfter - memBefore) / 1024 / 1024).toFixed(2)*/0} MB`;
    testDatum.performance = `${(end - start)} ms`;
    testDatum.language = 'Node.js';
    await this.testDataRepo.create(testDatum);
    return entities;
  }

  async getById(id: number) {
    const start = performance.now();
    const entity = await this.repo.findOneBy({ orderId: id });
    const end = performance.now();
    const testDatum = new TestData();
    testDatum.testName = 'Typeorm Get Operation';
    testDatum.cpuUsage = `${/*(cpuAfter.user / 1000).toFixed(2)*/0} ms`;
    testDatum.memoryUsage = `${/*((memAfter - memBefore) / 1024 / 1024).toFixed(2)*/0} MB`;
    testDatum.performance = `${(end - start)} ms`;
    testDatum.language = 'Node.js';
    await this.testDataRepo.create(testDatum);
    return entity;
  }

  async create(data: Partial<Orders>) {
    const start = performance.now();
    const entity = await this.repo.create(data);
    await this.repo.save(entity);
    const end = performance.now();
    const testDatum = new TestData();
    testDatum.testName = 'Typeorm Create Operation';
    testDatum.cpuUsage = `${/*(cpuAfter.user / 1000).toFixed(2)*/0} ms`;
    testDatum.memoryUsage = `${/*((memAfter - memBefore) / 1024 / 1024).toFixed(2)*/0} MB`;
    testDatum.performance = `${(end - start)} ms`;
    testDatum.language = 'Node.js';
    await this.testDataRepo.create(testDatum);
    return entity;
  }

  async update(id: number, updateData: Partial<Orders>) {
    const start = performance.now();
    const entity = await this.repo.findOneBy({ orderId: id });
    this.repo.merge(entity!, updateData);
    this.repo.save(entity!);
    const end = performance.now();
    const testDatum = new TestData();
    testDatum.testName = 'Typeorm Update Operation';
    testDatum.cpuUsage = `${/*(cpuAfter.user / 1000).toFixed(2)*/0} ms`;
    testDatum.memoryUsage = `${/*((memAfter - memBefore) / 1024 / 1024).toFixed(2)*/0} MB`;
    testDatum.performance = `${(end - start)} ms`;
    testDatum.language = 'Node.js';
    await this.testDataRepo.create(testDatum);
  }

  async delete(id: number) {
    const start = performance.now();
    await this.repo.delete(id);
    const end = performance.now();
    const testDatum = new TestData();
    testDatum.testName = 'Typeorm Update Operation';
    testDatum.cpuUsage = `${/*(cpuAfter.user / 1000).toFixed(2)*/0} ms`;
    testDatum.memoryUsage = `${/*((memAfter - memBefore) / 1024 / 1024).toFixed(2)*/0} MB`;
    testDatum.performance = `${(end - start)} ms`;
    testDatum.language = 'Node.js';
    await this.testDataRepo.create(testDatum);
  }
}
