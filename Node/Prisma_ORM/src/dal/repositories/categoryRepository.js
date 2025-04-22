const prisma = require('../db');
const GenericRepository = require('./genericRepository');

const baseRepository = GenericRepository(prisma.Categories, 'CategoryID');

const CategoryRepository = {
  ...baseRepository
};

module.exports = CategoryRepository;