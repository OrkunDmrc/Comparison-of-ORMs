const prisma = require('../db');
const TestDatumRepository = require('../../dal/repositories/testDatumRepository');
const { performance } = require('perf_hooks');
//onst GenericRepository = require('./genericRepository');

//const baseRepository = GenericRepository(prisma.Orders, 'OrderID');

/*const OrderRepository = {
  ...baseRepository
};*/

const OrderRepository = {
    getAll: async () => {
      const start = performance.now();
      const entities = await prisma.Orders.findMany();
      const end = performance.now();
      const testDatum = {
        Language: 'Node.js',
        TestName: 'Prisma Get All Operation',
        Performance: `${(end - start).toFixed(2)} ms`,
        MemoryUsage: `${/*((memAfter - memBefore) / 1024 / 1024).toFixed(2)*/0} MB`,
        CpuUsage: `${/*(cpuAfter.user / 1000).toFixed(2)*/0} ms`
      };
      await TestDatumRepository.create(testDatum);
      return entities;
    },

    getById: async (id) => {
      const start = performance.now();
      const entity = await prisma.Orders.findUnique({ where: { ['OrderID']: id } });
      const end = performance.now();
      const testDatum = {
        Language: 'Node.js',
        TestName: 'Prisma Get Operation',
        Performance: `${(end - start).toFixed(2)} ms`,
        MemoryUsage: `${/*((memAfter - memBefore) / 1024 / 1024).toFixed(2)*/0} MB`,
        CpuUsage: `${/*(cpuAfter.user / 1000).toFixed(2)*/0} ms`
      };
      await TestDatumRepository.create(testDatum);
      return entity;
    },

    create: async (data) => {
      const start = performance.now();
      const entity = await prisma.Orders.create({ data });
      const end = performance.now();
      const testDatum = {
        Language: 'Node.js',
        TestName: 'Prisma Create Operation',
        Performance: `${(end - start).toFixed(2)} ms`,
        MemoryUsage: `${/*((memAfter - memBefore) / 1024 / 1024).toFixed(2)*/0} MB`,
        CpuUsage: `${/*(cpuAfter.user / 1000).toFixed(2)*/0} ms`
      };
      await TestDatumRepository.create(testDatum);
      return entity;
    },

    update: async (id, data) => {
      const start = performance.now();
      await prisma.Orders.update({
        where: { ['OrderID']: id },
        data,
      });
      const end = performance.now();
      const testDatum = {
        Language: 'Node.js',
        TestName: 'Prisma Update Operation',
        Performance: `${(end - start).toFixed(2)} ms`,
        MemoryUsage: `${/*((memAfter - memBefore) / 1024 / 1024).toFixed(2)*/0} MB`,
        CpuUsage: `${/*(cpuAfter.user / 1000).toFixed(2)*/0} ms`
      };
      await TestDatumRepository.create(testDatum);
    },

    delete: async (id) => {
      const start = performance.now();
      await prisma.Orders.delete({
        where: { ['OrderID']: id },
      });
      const end = performance.now();
      const testDatum = {
        Language: 'Node.js',
        TestName: 'Prisma Delete Operation',
        Performance: `${(end - start).toFixed(2)} ms`,
        MemoryUsage: `${/*((memAfter - memBefore) / 1024 / 1024).toFixed(2)*/0} MB`,
        CpuUsage: `${/*(cpuAfter.user / 1000).toFixed(2)*/0} ms`
      };
      await TestDatumRepository.create(testDatum);
  }
}

module.exports = OrderRepository;