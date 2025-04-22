const prisma = require('../db');
const GenericRepository = require('./genericRepository');

const baseRepository = GenericRepository(prisma.TestData, 'Id');

const TestDataRepository = {
  ...baseRepository
};

module.exports = TestDataRepository;