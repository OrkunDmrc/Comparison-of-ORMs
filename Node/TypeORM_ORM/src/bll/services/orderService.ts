import { OrderRepository } from '../../dal/repositories/orderRepository';
import { Orders } from '../../dal/entities/Orders';

const process = require('process');

export class OrderService {
  private orderRepository = new OrderRepository();

  async getAll() {
    return await this.orderRepository.getAll();
  }

  async getById(id: number) {
    return await this.orderRepository.getById(id);
  }

  async create(entity: Partial<Orders>) {
    return await this.orderRepository.create(entity);
  }

  async update(id: number, entity: Partial<Orders>) {
    await this.orderRepository.update(id, entity);
  }

  async delete(id: number) {
    await this.orderRepository.delete(id);
  }
}

export default OrderService;