const prisma = require('../db');
//onst GenericRepository = require('./genericRepository');

//const baseRepository = GenericRepository(prisma.Orders, 'OrderID');

/*const OrderRepository = {
  ...baseRepository
};*/

const OrderRepository = {
    getAll: async () => await prisma.Orders.findMany(),

    getById: async (id) => await prisma.Orders.findUnique({ where: { ['OrderID']: id } }),

    create: async (data) => await prisma.Orders.create({ data }),

    update: async (id, data) => await prisma.Orders.update({
      where: { ['OrderID']: id },
      data,
    }),

    delete: async (id) => prisma.Orders.delete({
      where: { ['OrderID']: id },
    })
}

module.exports = OrderRepository;