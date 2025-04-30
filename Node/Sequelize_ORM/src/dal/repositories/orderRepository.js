const { models } = require('../../config/db');
const TestDatumRepository = require('../../dal/repositories/testDatumRepository');
const { performance } = require('perf_hooks');
//const GenericRepository = require('./genericRepository');

/*class OrderRepository extends GenericRepository { 
  constructor() {
    super(models.Orders);
  }
}*/

class OrderRepository {
  async getAll() {
    const start = performance.now();
    const entities = await models.Orders.findAll();
    const end = performance.now();
    const testDatum = {
      Language: 'Node js',
      TestName: 'Sequelize Get All Operation',
      Performance: `${(end - start)} ms`,
      MemoryUsage: `${/*((memAfter - memBefore) / 1024 / 1024).toFixed(2)*/0} MB`,
      CpuUsage: `${/*(cpuAfter.user / 1000).toFixed(2)*/0} ms`
    };
    await TestDatumRepository.create(testDatum);
    return entities;
  }

  async getById(id) {
    const start = performance.now();
    const entity = await models.Orders.findByPk(id);
    const end = performance.now();
    const testDatum = {
      Language: 'Node js',
      TestName: 'Sequelize Get All Operation',
      Performance: `${(end - start)} ms`,
      MemoryUsage: `${/*((memAfter - memBefore) / 1024 / 1024).toFixed(2)*/0} MB`,
      CpuUsage: `${/*(cpuAfter.user / 1000).toFixed(2)*/0} ms`
    };
    await TestDatumRepository.create(testDatum);
    return entity;
  }

  async create(data) {
    const start = performance.now();
    const entity = await models.Orders.create(data);
    const end = performance.now();
    const testDatum = {
      Language: 'Node js',
      TestName: 'Sequelize Create Operation',
      Performance: `${(end - start)} ms`,
      MemoryUsage: `${/*((memAfter - memBefore) / 1024 / 1024).toFixed(2)*/0} MB`,
      CpuUsage: `${/*(cpuAfter.user / 1000).toFixed(2)*/0} ms`
    };
    await TestDatumRepository.create(testDatum);
    return entity;
  }

  async update(id, data) {
    const start = performance.now();
    const entity = await models.Orders.findByPk(id);
    await entity.update(data);
    const end = performance.now();
    const testDatum = {
      Language: 'Node js',
      TestName: 'Sequelize Update Operation',
      Performance: `${(end - start)} ms`,
      MemoryUsage: `${/*((memAfter - memBefore) / 1024 / 1024).toFixed(2)*/0} MB`,
      CpuUsage: `${/*(cpuAfter.user / 1000).toFixed(2)*/0} ms`
    };
    await TestDatumRepository.create(testDatum);
  }

  async delete(id) {
    const start = performance.now();
    const entity = models.Orders.findByPk(id);
    await entity.destroy();
    const end = performance.now();
    const testDatum = {
      Language: 'Node js',
      TestName: 'Sequelize Delete Operation',
      Performance: `${(end - start)} ms`,
      MemoryUsage: `${/*((memAfter - memBefore) / 1024 / 1024).toFixed(2)*/0} MB`,
      CpuUsage: `${/*(cpuAfter.user / 1000).toFixed(2)*/0} ms`
    };
    await TestDatumRepository.create(testDatum);
  }
}

module.exports = new OrderRepository();