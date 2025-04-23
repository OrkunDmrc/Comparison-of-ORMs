const { models } = require('../../config/db');
const GenericRepository = require('./genericRepository');

class ShipperRepository extends GenericRepository { 
  constructor() {
    super(models.Shippers);
  }
}

module.exports = new ShipperRepository();