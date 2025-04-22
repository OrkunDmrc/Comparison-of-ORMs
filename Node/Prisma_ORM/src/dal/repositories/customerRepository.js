const prisma = require('../db');
const GenericRepository = require('./genericRepository');

const baseRepository = GenericRepository(prisma.Customers, 'CustomerID');

const CustomerRepository = {
  ...baseRepository
};

module.exports = CustomerRepository;