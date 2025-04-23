import { Shippers } from 'dal/entities/Shippers';
import { ShipperRepository } from '../../dal/repositories/shipperRepository';

export class ShipperService {
  private shipperRepository = new ShipperRepository();
  async getAll() {
    return await this.shipperRepository.getAll();
  }

  async getById(id: number) {
    return await this.shipperRepository.getById(id);
  }

  async create(data: Partial<Shippers>) {
    return await this.shipperRepository.create(data);
  }

  async update(id: number, data: Partial<Shippers>) {
    return await this.shipperRepository.update(id, data);
  }

  async delete(id: number) {
    return await this.shipperRepository.delete(id);
  }
}