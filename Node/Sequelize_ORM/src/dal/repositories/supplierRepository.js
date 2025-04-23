const { models } = require('../../config/db');
const GenericRepository = require('./genericRepository');

class SupplierRepository extends GenericRepository { 
  constructor() {
    super(models.Suppliers);
  }
}

module.exports = new SupplierRepository();