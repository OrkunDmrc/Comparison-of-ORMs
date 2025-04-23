const { models } = require('../../config/db');

class OrderDetailRepository { 
    async getAll() {
        return await models.OrderDetails.findAll();
    }
    async getById(orderID, productID) {
        return await models.OrderDetails.findOne({
            where: { orderID: orderID, productID: productID }
        });
    }
    async create(entity) {
        return await models.OrderDetails.create(entity);
    }
    async delete (orderID, productID) {
        const entity = await models.OrderDetails.findOne({
            where: { orderID: orderID, productID: productID }
        });
        return entity ? await entity.destroy() : null;
    }
}

module.exports = new OrderDetailRepository();