const prisma = require('../db');

const OrderDetailRepository = {
  getAll: async () => {
    return await prisma.categories.findMany();
  },

  getById: async (orderID, productID) => {
    return await prisma.categories.findUnique({
      where: { orderID: orderID, productID: productID }
    });
  },

  create: async (entity) => {
    return await prisma.categories.create({ data: entity });
  },

  delete: async (orderID, productID) => {
    return await prisma.categories.delete({ 
      where: { orderID: orderID, productID: productID }
    });
  },
}

module.exports = OrderDetailRepository;