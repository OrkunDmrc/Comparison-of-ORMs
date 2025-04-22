const prisma = require('../db');
const GenericRepository = require('./genericRepository');

const baseRepository = GenericRepository(prisma.Suppliers, 'SupplierID');

const SupplierRepository = {
  ...baseRepository
};

module.exports = SupplierRepository;