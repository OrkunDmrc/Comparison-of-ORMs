import { OrderDetails } from 'dal/entities/OrderDetails';
import { OrderDetailRepositories } from '../../dal/repositories/orderDetailRepository';

export class OrderDetailService {
  private orderDetailRepository = new OrderDetailRepositories();
  
  async getAll() {
    return await this.orderDetailRepository.getAll();
  }

  async getById(orderID: number, productID: number) {
    return await this.orderDetailRepository.getById(orderID, productID);
  }

  async create(data: Partial<OrderDetails>) {
    return await this.orderDetailRepository.create(data);
  }

  async delete(orderID: number, productID: number) {
    return await this.orderDetailRepository.delete(orderID, productID);
  }
}
