const { sequelize, models } = require('../../config/db');
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
    console.log("data", data);
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
    const entity = await models.Orders.findByPk(id);
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

  async allTables() {
    const start = performance.now();
    const results = await sequelize.query(`
      SELECT o.*, e.*, c.*, s.*, od.*, p.*, ct.*, sp.*, et.*, t.*, r.*
      FROM Orders o
      JOIN Employees e ON e.EmployeeID = o.EmployeeID
      JOIN Customers c ON c.CustomerID = o.CustomerID
      JOIN Shippers s ON s.ShipperID = o.ShipVia
      JOIN [Order Details] od ON od.OrderID = o.OrderID
      JOIN Products p ON p.ProductID = od.ProductID
      JOIN Categories ct ON ct.CategoryID = p.CategoryID
      JOIN Suppliers sp ON sp.SupplierID = p.SupplierID
      JOIN EmployeeTerritories et ON et.EmployeeID = e.EmployeeID
      JOIN Territories t ON t.TerritoryID = et.TerritoryID
      JOIN Region r ON r.RegionID = t.RegionID
    `, { type: sequelize.QueryTypes.SELECT });
    const end = performance.now();
    const testDatum = {
      Language: 'Node js',
      TestName: 'Sequelize All Tables Operation',
      Performance: `${(end - start)} ms`,
      MemoryUsage: `${/*((memAfter - memBefore) / 1024 / 1024).toFixed(2)*/0} MB`,
      CpuUsage: `${/*(cpuAfter.user / 1000).toFixed(2)*/0} ms`
    };
    await TestDatumRepository.create(testDatum);
  }
}

module.exports = new OrderRepository();