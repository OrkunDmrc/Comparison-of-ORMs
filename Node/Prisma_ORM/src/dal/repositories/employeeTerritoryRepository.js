const prisma = require('../db');
const GenericRepository = require('./genericRepository');

const baseRepository = GenericRepository(prisma.EmployeeTerritory, 'EmployeeID');

const EmployeeTerritoryRepository = {
  ...baseRepository
};

module.exports = EmployeeTerritoryRepository;