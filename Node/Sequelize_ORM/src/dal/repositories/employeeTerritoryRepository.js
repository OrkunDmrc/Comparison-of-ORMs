const { models } = require('../../config/db');
const GenericRepository = require('./genericRepository');

class EmployeeTerritoryRepository extends GenericRepository { 
  constructor() {
    super(models.EmployeeTerritories);
  }
}

module.exports = new EmployeeTerritoryRepository();