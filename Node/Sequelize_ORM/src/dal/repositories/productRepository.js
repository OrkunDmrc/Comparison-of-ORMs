const { models } = require('../../config/db');
const GenericRepository = require('./genericRepository');

class ProductRepository extends GenericRepository { 
  constructor() {
    super(models.Products);
  }
}

module.exports = new ProductRepository();