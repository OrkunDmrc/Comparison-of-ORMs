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
  },

  allTables: async () => {
    const start = performance.now();
    const results = await prisma.$queryRawUnsafe(`
      select o.*, e.*, c.*, s.*, od.*, p.*, ct.*, sp.*, et.*, t.*, r.* from Orders o
      join Employees e on e.EmployeeID = o.EmployeeID
      join Customers c on c.CustomerID = o.CustomerID
      join Shippers s on s.ShipperID = o.ShipVia
      join [Order Details] od on od.OrderID = o.OrderID
      join Products p on p.ProductID = od.ProductID
      join Categories ct on ct.CategoryID = p.CategoryID
      join Suppliers sp on sp.SupplierID = p.SupplierID
      join EmployeeTerritories et on et.EmployeeID = e.EmployeeID
      join Territories t on t.TerritoryID = et.TerritoryID
      join Region r on r.RegionID = t.RegionID
    `);
    const end = performance.now();
    const testDatum = {
      Language: 'Node.js',
      TestName: 'Prisma All Tables Operation',
      Performance: `${(end - start).toFixed(2)} ms`,
      MemoryUsage: `${/*((memAfter - memBefore) / 1024 / 1024).toFixed(2)*/0} MB`,
      CpuUsage: `${/*(cpuAfter.user / 1000).toFixed(2)*/0} ms`
    };
    await TestDatumRepository.create(testDatum);
  }
}

module.exports = OrderRepository;