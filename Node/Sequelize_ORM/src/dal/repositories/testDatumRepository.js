const { models } = require('../../config/db');
const GenericRepository = require('./genericRepository');

class TestDatumRepository extends GenericRepository { 
  constructor() {
    super(models.TestData);
  }
}

module.exports = new TestDatumRepository();