import { Repository, ObjectLiteral } from 'typeorm';

export class GenericRepository<T extends ObjectLiteral, TKey extends number | string = number> {
  private repo: Repository<T>;
  private keyName: keyof T;

  constructor(repo: Repository<T>, keyName: keyof T) {
    this.repo = repo;
    this.keyName = keyName;
  }

  async getAll() {
    return this.repo.find();
  }

  async getById(id: TKey) {
    return this.repo.findOneBy({ [this.keyName]: id } as any);
  }

  async create(data: Partial<T>) {
    const entity = this.repo.create(data as T);
    return this.repo.save(entity);
  }

  async update(id: TKey, updateData: Partial<T>) {
    const entity = await this.getById(id);
    if (!entity) return null;

    this.repo.merge(entity, updateData as T);
    return this.repo.save(entity);
  }

  async delete(id: TKey) {
    const result = await this.repo.delete(id);
    return result.affected !== 0;
  }
}
