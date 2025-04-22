const prisma = require('../db');
const GenericRepository = require('./genericRepository');

const baseRepository = GenericRepository(prisma.Employees, 'EmployeeID');

const EmployeeRepository = {
  ...baseRepository
};

module.exports = EmployeeRepository;