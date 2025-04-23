const { models } = require('../../config/db');
const GenericRepository = require('./genericRepository');

class CustomerRepository extends GenericRepository { 
  constructor() {
    super(models.Customers);
  }
}

module.exports = new CustomerRepository();