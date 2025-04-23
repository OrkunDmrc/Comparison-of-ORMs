import { AppDataSource } from '../../config/data-source';
import { OrderDetails } from '../entities/OrderDetails';

export class OrderDetailRepositories {
    private repo = AppDataSource.getRepository(OrderDetails);
    
    async getAll() {
        return await this.repo.find();
    }

    async getById(orderID: number, productID: number) {
        return await this.repo.findOneBy({ orderId: orderID, productId: productID });
    }

    async create(data: Partial<OrderDetails>) {
        const entity = this.repo.create(data);
        return this.repo.save(entity);
    }

    async delete (orderID: number, productID: number) {
        await this.repo.delete({ orderId: orderID, productId: productID });
    }
}
