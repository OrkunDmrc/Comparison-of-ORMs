from dal.repositories.product_repository import ProductRepository
from dal.data.database import SessionLocal
from dal.entities.product import Product

class ProductService:
    def __init__(self):
        self.db = SessionLocal()
        self.repo = ProductRepository(self.db)

    def get_by_id(self, id: str):
        entity = self.repo.get_by_id(id)
        if not entity:
            raise ValueError(f"Entity {id} not found")
        return entity

    def get_all(self):
        return self.repo.get_all()

    def create(self, entity: Product) -> Product:
        return self.repo.create(entity)

    def update(self, id: int, entity: Product) -> Product:
        entity = self.repo.update(id, entity)
        if not entity:
            raise ValueError(f"Entity {id} not found for update")
        return entity

    def delete(self, id: int):
        entity = self.repo.delete(id)
        if not entity:
            raise ValueError(f"Entity {id} not found for deletion")
        return entity