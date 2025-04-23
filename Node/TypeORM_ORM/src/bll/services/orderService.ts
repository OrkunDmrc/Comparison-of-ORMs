import { performance } from 'perf_hooks';
import { OrderRepository } from '../../dal/repositories/orderRepository';
import { TestDatumRepository } from '../../dal/repositories/testDatumRepository';
import { TestData } from '../../dal/entities/TestData';
import { Orders } from '../../dal/entities/Orders';

const process = require('process');

export class OrderService {
  private orderRepository = new OrderRepository();
  private testDatumRepository = new TestDatumRepository();

  async getAll() {
    const cpuBefore = process.cpuUsage();
    const memBefore = process.memoryUsage().rss;
    const start = performance.now();

    const entities = await this.orderRepository.getAll();
    
    const end = performance.now();
    const memAfter = process.memoryUsage().rss;
    const cpuAfter = process.cpuUsage(cpuBefore); 

    const testDatum = new TestData();
    testDatum.testName = 'Typeorm Get All Operation';
    testDatum.cpuUsage = `${(cpuAfter.user / 1000).toFixed(2)} ms`;
    testDatum.memoryUsage = `${((memAfter - memBefore) / 1024 / 1024).toFixed(2)} MB`;
    testDatum.performance = `${(end - start).toFixed(2)} ms`;
    testDatum.language = 'Node.js';

    await this.testDatumRepository.create(testDatum);

    return entities
  }

  async getById(id: number) {
    const cpuBefore = process.cpuUsage();
    const memBefore = process.memoryUsage().rss;
    const start = performance.now();

    const entity = await this.orderRepository.getById(id);

    const end = performance.now();
    const memAfter = process.memoryUsage().rss;
    const cpuAfter = process.cpuUsage(cpuBefore);

    const testDatum = new TestData();
    testDatum.testName = 'Typeorm Get Operation';
    testDatum.cpuUsage = `${(cpuAfter.user / 1000).toFixed(2)} ms`;
    testDatum.memoryUsage = `${((memAfter - memBefore) / 1024 / 1024).toFixed(2)} MB`;
    testDatum.performance = `${(end - start).toFixed(2)} ms`;
    testDatum.language = 'Node.js';

    await this.testDatumRepository.create(testDatum);

    if (!entity) throw new Error('entity not found');
    return entity;
  }

  async create(entity: Partial<Orders>) {
    const cpuBefore = process.cpuUsage();
    const memBefore = process.memoryUsage().rss;
    const start = performance.now();

    const newEntity = await this.orderRepository.create(entity);

    const end = performance.now();
    const memAfter = process.memoryUsage().rss;
    const cpuAfter = process.cpuUsage(cpuBefore);

    const testDatum = new TestData();
    testDatum.testName = 'Typeorm Create Operation';
    testDatum.cpuUsage = `${(cpuAfter.user / 1000).toFixed(2)} ms`;
    testDatum.memoryUsage = `${((memAfter - memBefore) / 1024 / 1024).toFixed(2)} MB`;
    testDatum.performance = `${(end - start).toFixed(2)} ms`;
    testDatum.language = 'Node.js';

    await this.testDatumRepository.create(testDatum);

    return newEntity
  }

  async update(id: number, entity: Partial<Orders>) {
    const cpuBefore = process.cpuUsage();
    const memBefore = process.memoryUsage().rss;
    const start = performance.now();

    const newEntity = await this.orderRepository.update(id, entity);

    const end = performance.now();
    const memAfter = process.memoryUsage().rss;
    const cpuAfter = process.cpuUsage(cpuBefore);

    const testDatum = new TestData();
    testDatum.testName = 'Typeorm Update Operation';
    testDatum.cpuUsage = `${(cpuAfter.user / 1000).toFixed(2)} ms`;
    testDatum.memoryUsage = `${((memAfter - memBefore) / 1024 / 1024).toFixed(2)} MB`;
    testDatum.performance = `${(end - start).toFixed(2)} ms`;
    testDatum.language = 'Node.js';

    await this.testDatumRepository.create(testDatum);

    return newEntity;
  }

  async delete(id: number) {
    const cpuBefore = process.cpuUsage();
    const memBefore = process.memoryUsage().rss;
    const start = performance.now();

    const entity = await this.orderRepository.delete(id);

    const end = performance.now();
    const memAfter = process.memoryUsage().rss;
    const cpuAfter = process.cpuUsage(cpuBefore);

    const testDatum = new TestData();
    testDatum.testName = 'Typeorm Delete Operation';
    testDatum.cpuUsage = `${(cpuAfter.user / 1000).toFixed(2)} ms`;
    testDatum.memoryUsage = `${((memAfter - memBefore) / 1024 / 1024).toFixed(2)} MB`;
    testDatum.performance = `${(end - start).toFixed(2)} ms`;
    testDatum.language = 'Node.js';

    await this.testDatumRepository.create(testDatum);
    
    return entity;
  }
}

export default OrderService;