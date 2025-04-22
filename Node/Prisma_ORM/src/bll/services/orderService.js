const { performance } = require('perf_hooks');
const process = require('process');
const OrderRepository = require('../../dal/repositories/orderRepository');
const TestDatumRepository = require('../../dal/repositories/testDatumRepository');

const OrderService = {
  getAll: async () => {
    const cpuBefore = process.cpuUsage();
    const memBefore = process.memoryUsage().rss;
    const start = performance.now();

    const entities = await OrderRepository.getAll();

    const end = performance.now();
    const memAfter = process.memoryUsage().rss;
    const cpuAfter = process.cpuUsage(cpuBefore); 

    const testDatum = {
      Language: 'Node.js',
      TestName: 'Prisma Get All Operation',
      Performance: `${(end - start).toFixed(2)} ms`,
      MemoryUsage: `${((memAfter - memBefore) / 1024 / 1024).toFixed(2)} MB`,
      CpuUsage: `${(cpuAfter.user / 1000).toFixed(2)} ms`
    };

    await TestDatumRepository.create(testDatum);

    return entities
  },

  getById: async (id) => {
    const cpuBefore = process.cpuUsage();
    const memBefore = process.memoryUsage().rss;
    const start = performance.now();

    const entity = await OrderRepository.getById(id);

    const end = performance.now();
    const memAfter = process.memoryUsage().rss;
    const cpuAfter = process.cpuUsage(cpuBefore);

    const testDatum = {
      Language: 'Node js',
      TestName: 'Prisma Get Operation',
      Performance: `${(end - start).toFixed(2)} ms`,
      MemoryUsage: `${((memAfter - memBefore) / 1024 / 1024).toFixed(2)} MB`,
      CpuUsage: `${(cpuAfter.user / 1000).toFixed(2)} ms`
    };

    await TestDatumRepository.create(testDatum);

    if (!entity) throw new Error('entity not found');
    return entity;
  },

  create: async (entity) => {
    const cpuBefore = process.cpuUsage();
    const memBefore = process.memoryUsage().rss;
    const start = performance.now();

    const newEntity = await OrderRepository.create(entity);

    const end = performance.now();
    const memAfter = process.memoryUsage().rss;
    const cpuAfter = process.cpuUsage(cpuBefore);

    const testDatum = {
      Language: 'Node js',
      TestName: 'Prisma Create Operation',
      Performance: `${(end - start).toFixed(2)} ms`,
      MemoryUsage: `${((memAfter - memBefore) / 1024 / 1024).toFixed(2)} MB`,
      CpuUsage: `${(cpuAfter.user / 1000).toFixed(2)} ms`
    };

    await TestDatumRepository.create(testDatum);

    return newEntity
  },

  update: async (id, entity) => {
    const cpuBefore = process.cpuUsage();
    const memBefore = process.memoryUsage().rss;
    const start = performance.now();

    const newEntity = await OrderRepository.update(id, entity);

    const end = performance.now();
    const memAfter = process.memoryUsage().rss;
    const cpuAfter = process.cpuUsage(cpuBefore);

    const testDatum = {
      Language: 'Node js',
      TestName: 'Prisma Create Operation',
      Performance: `${(end - start).toFixed(2)} ms`,
      MemoryUsage: `${((memAfter - memBefore) / 1024 / 1024).toFixed(2)} MB`,
      CpuUsage: `${(cpuAfter.user / 1000).toFixed(2)} ms`
    };

    await TestDatumRepository.create(testDatum);

    return newEntity;
  },

  delete: async (id) => {
    const cpuBefore = process.cpuUsage();
    const memBefore = process.memoryUsage().rss;
    const start = performance.now();

    const entity = await OrderRepository.delete(id);

    const end = performance.now();
    const memAfter = process.memoryUsage().rss;
    const cpuAfter = process.cpuUsage(cpuBefore);

    const testDatum = {
      Language: 'Node js',
      TestName: 'Prisma Create Operation',
      Performance: `${(end - start).toFixed(2)} ms`,
      MemoryUsage: `${((memAfter - memBefore) / 1024 / 1024).toFixed(2)} MB`,
      CpuUsage: `${(cpuAfter.user / 1000).toFixed(2)} ms`
    };

    await TestDatumRepository.create(testDatum);
    
    return entity;
  }
};

module.exports = OrderService; 