const { performance } = require('perf_hooks');
const process = require('process');
const OrderRepository = require('../../dal/repositories/orderRepository');
const TestDatumRepository = require('../../dal/repositories/testDatumRepository');

class OrderService {
  async getAll() {
    const cpuBefore = process.cpuUsage();
    const memBefore = process.memoryUsage().rss;
    const start = performance.now();

    const entities = await OrderRepository.getAll();
    
    const end = performance.now();
    const memAfter = process.memoryUsage().rss;
    const cpuAfter = process.cpuUsage(cpuBefore); 

    const testDatum = {
      Language: 'Node.js',
      TestName: 'Sequelize Get All Operation',
      Performance: `${(end - start).toFixed(2)} ms`,
      MemoryUsage: `${((memAfter - memBefore) / 1024 / 1024).toFixed(2)} MB`,
      CpuUsage: `${(cpuAfter.user / 1000).toFixed(2)} ms`
    };

    
    await TestDatumRepository.create(testDatum);
    return entities
  }

  async getById(id) {
    const cpuBefore = process.cpuUsage();
    const memBefore = process.memoryUsage().rss;
    const start = performance.now();

    const entity = await OrderRepository.getById(id);

    const end = performance.now();
    const memAfter = process.memoryUsage().rss;
    const cpuAfter = process.cpuUsage(cpuBefore);

    const testDatum = {
      Language: 'Node js',
      TestName: 'Sequelize Get Operation',
      Performance: `${(end - start).toFixed(2)} ms`,
      MemoryUsage: `${((memAfter - memBefore) / 1024 / 1024).toFixed(2)} MB`,
      CpuUsage: `${(cpuAfter.user / 1000).toFixed(2)} ms`
    };

    await TestDatumRepository.create(testDatum);

    if (!entity) throw new Error('entity not found');
    return entity;
  }

  async create(entity) {
    const cpuBefore = process.cpuUsage();
    const memBefore = process.memoryUsage().rss;
    const start = performance.now();

    const newEntity = await OrderRepository.create(entity);

    const end = performance.now();
    const memAfter = process.memoryUsage().rss;
    const cpuAfter = process.cpuUsage(cpuBefore);

    const testDatum = {
      Language: 'Node js',
      TestName: 'Sequelize Create Operation',
      Performance: `${(end - start).toFixed(2)} ms`,
      MemoryUsage: `${((memAfter - memBefore) / 1024 / 1024).toFixed(2)} MB`,
      CpuUsage: `${(cpuAfter.user / 1000).toFixed(2)} ms`
    };

    await TestDatumRepository.create(testDatum);

    return newEntity
  }

  async update(id, entity) {
    const cpuBefore = process.cpuUsage();
    const memBefore = process.memoryUsage().rss;
    const start = performance.now();

    const newEntity = await OrderRepository.update(id, entity);

    const end = performance.now();
    const memAfter = process.memoryUsage().rss;
    const cpuAfter = process.cpuUsage(cpuBefore);

    const testDatum = {
      Language: 'Node js',
      TestName: 'Sequelize Update Operation',
      Performance: `${(end - start).toFixed(2)} ms`,
      MemoryUsage: `${((memAfter - memBefore) / 1024 / 1024).toFixed(2)} MB`,
      CpuUsage: `${(cpuAfter.user / 1000).toFixed(2)} ms`
    };

    await TestDatumRepository.create(testDatum);

    return newEntity;
  }

  async delete(id) {
    const cpuBefore = process.cpuUsage();
    const memBefore = process.memoryUsage().rss;
    const start = performance.now();

    const entity = await OrderRepository.delete(id);

    const end = performance.now();
    const memAfter = process.memoryUsage().rss;
    const cpuAfter = process.cpuUsage(cpuBefore);

    const testDatum = {
      Language: 'Node js',
      TestName: 'Sequelize Delete Operation',
      Performance: `${(end - start).toFixed(2)} ms`,
      MemoryUsage: `${((memAfter - memBefore) / 1024 / 1024).toFixed(2)} MB`,
      CpuUsage: `${(cpuAfter.user / 1000).toFixed(2)} ms`
    };

    await TestDatumRepository.create(testDatum);
    
    return entity;
  }
}

module.exports = new OrderService(); 