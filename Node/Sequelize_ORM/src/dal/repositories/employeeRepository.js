const { models } = require('../../config/db');
const GenericRepository = require('./genericRepository');

class EmployeeRepository extends GenericRepository { 
  constructor() {
    super(models.Employees);
  }
}

module.exports = new EmployeeRepository();