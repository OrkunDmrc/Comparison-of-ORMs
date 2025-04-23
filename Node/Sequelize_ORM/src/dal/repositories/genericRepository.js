class GenericRepositry {
    constructor(model) {
        this.model = model;
    }

    async getAll() {
        return await this.model.findAll();
    }

    async getById(id) {
        return await this.model.findByPk(id);
    }

    async create(data) {
        return await this.model.create(data);
    }

    async update(id, data) {
        const entity = await this.model.findByPk(id);
        return entity ? await entity.update(data) : null;
    }

    async delete(id) {
        const entity = await this.model.findByPk(id);
        return entity ? await entity.destroy() : null;
    }
}

module.exports = GenericRepositry;