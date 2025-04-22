const prisma = require('../db');
const GenericRepository = require('./genericRepository');

const baseRepository = GenericRepository(prisma.Products, 'ProductID');

const ProductRepository = {
  ...baseRepository
};

module.exports = ProductRepository;