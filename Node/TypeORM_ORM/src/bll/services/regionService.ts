import { Region } from 'dal/entities/Region';
import { RegionRepository } from '../../dal/repositories/regionRepository';

export class RegionService {
  private regionRepository = new RegionRepository();
  async getAll() {
    return await this.regionRepository.getAll();
  }

  async getById(id: number) {
    return await this.regionRepository.getById(id);
  }

  async create(data: Partial<Region>) {
    return await this.regionRepository.create(data);
  }

  async update(id: number, data: Partial<Region>) {
    return await this.regionRepository.update(id, data);
  }

  async delete(id: number) {
    return await this.regionRepository.delete(id);
  }
}
