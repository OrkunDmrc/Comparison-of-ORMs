import { Categories } from "../../dal/entities/Categories";
import { CategoryRepository } from "../../dal/repositories/categoryRepositroy";

export class CategoryService {
    private categoryRepository = new CategoryRepository();
    
    async getAll() {
        return await this.categoryRepository.getAll();
    }
    
    async getById(id: number) {
        return await this.categoryRepository.getById(id);
    }
    
    async create(data: Partial<Categories>) {
        return await this.categoryRepository.create(data);
    }
    
    async update(id: number, data: Partial<Categories>) {
        return await this.categoryRepository.update(id, data);
    }
    
    async delete(id: number) {
        return await this.categoryRepository.delete(id);
    }
}

