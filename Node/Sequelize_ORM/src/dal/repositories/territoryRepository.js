const { models } = require('../../config/db');
const GenericRepository = require('./genericRepository');

class TerritoryRepository extends GenericRepository { 
  constructor() {
    super(models.Territories);
  }
}

module.exports = new TerritoryRepository();