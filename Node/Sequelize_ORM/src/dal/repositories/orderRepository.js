const { models } = require('../../config/db');
const GenericRepository = require('./genericRepository');

class OrderRepository extends GenericRepository { 
  constructor() {
    super(models.Orders);
  }
}

module.exports = new OrderRepository();