const prisma = require('../db');
const GenericRepository = require('./genericRepository');

const baseRepository = GenericRepository(prisma.Regions, 'RegionID');

const RegionRepository = {
  ...baseRepository
};

module.exports = RegionRepository;