import  { TerritoryRepository } from '../../dal/repositories/territoryRepository'
import { Territories } from '../../dal/entities/Territories.js';

export class TerritoryService {
  private territoryRepository = new TerritoryRepository();
  async getAll() {
    return await this.territoryRepository.getAll();
  }

  async getById(id: string) {
    return await this.territoryRepository.getById(id);
  }

  async create(data: Partial<Territories>) {
    return await this.territoryRepository.create(data);
  }

  async update(id: string, data: Partial<Territories>) {
    return await this.territoryRepository.update(id, data);
  }

  async delete(id: string) {
    return await this.territoryRepository.delete(id);
  }
}
