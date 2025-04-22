const prisma = require('../db');
const GenericRepository = require('./genericRepository');

const baseRepository = GenericRepository(prisma.Orders, 'OrderID');

const OrderRepository = {
  ...baseRepository
};

module.exports = OrderRepository;