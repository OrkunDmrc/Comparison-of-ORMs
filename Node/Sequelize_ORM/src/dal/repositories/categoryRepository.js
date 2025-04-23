const { models } = require('../../config/db');
const GenericRepository = require('./genericRepository');

class CategoryRepository extends GenericRepository { 
  constructor() {
    super(models.Categories);
  }
}

/*class CategoryRepository {
  async getAll() {
    return await Categories.findAll();
  }

  async getById(id) {
    return await Categories.findByPk(id);
  }

  async create(data) {
    return await Categories.create(data);
  }

  async update(id, data) {
    const entity = await Categories.findByPk(id);
    return entity ? await entity.update(data) : null;
  }

  async delete(id) {
    const entity = await Categories.findByPk(id);
    return entity ? await entity.destroy() : null;
  }
}*/

module.exports = new CategoryRepository();