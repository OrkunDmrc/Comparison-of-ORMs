const { models } = require('../../config/db');
//const GenericRepository = require('./genericRepository');

/*class OrderRepository extends GenericRepository { 
  constructor() {
    super(models.Orders);
  }
}*/

class OrderRepository {
  async getAll() {
      return await models.Orders.findAll();
  }

  async getById(id) {
      return await models.Orders.findByPk(id);
  }

  async create(data) {
      return await models.Orders.create(data);
  }

  async update(id, data) {
      const entity = models.Orders.findByPk(id);
      return entity ? await entity.update(data) : null;
  }

  async delete(id) {
      const entity = models.Orders.findByPk(id);
      return entity ? await entity.destroy() : null;
  }
}

module.exports = new OrderRepository();