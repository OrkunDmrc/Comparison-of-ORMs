const { models } = require('../../config/db');
const GenericRepository = require('./genericRepository');

class RegionRepository extends GenericRepository { 
  constructor() {
    super(models.Regions);
  }
}

module.exports = new RegionRepository();