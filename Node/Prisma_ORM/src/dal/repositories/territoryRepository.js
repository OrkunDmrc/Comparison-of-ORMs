const prisma = require('../db');
const GenericRepository = require('./genericRepository');

const baseRepository = GenericRepository(prisma.Territories, 'TerritoryID');

const TerritoryRepository = {
  ...baseRepository
};

module.exports = TerritoryRepository;