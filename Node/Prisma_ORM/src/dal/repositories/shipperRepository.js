const prisma = require('../db');
const GenericRepository = require('./genericRepository');

const baseRepository = GenericRepository(prisma.Shippers, 'ShipperID');

const ShipperRepository = {
  ...baseRepository
};

module.exports = ShipperRepository;