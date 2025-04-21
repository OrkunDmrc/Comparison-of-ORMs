from dal.repositories.supplier_repository import SupplierRepository
from dal.data.database import SessionLocal
from dal.entities.supplier import Supplier

class SupplierService:
    def __init__(self):
        self.db = SessionLocal()
        self.repo = SupplierRepository(self.db)

    def get_by_id(self, id: int):
        entity = self.repo.get_by_id(id)
        if not entity:
            raise ValueError(f"Entity {id} not found")
        return entity

    def get_all(self):
        return self.repo.get_all()

    def create(self, entity: Supplier) -> Supplier:
        return self.repo.create(entity)

    def update(self, id: int, entity: Supplier) -> Supplier:
        entity = self.repo.update(id, entity)
        if not entity:
            raise ValueError(f"Entity {id} not found for update")
        return entity

    def delete(self, id: int):
        entity = self.repo.delete(id)
        if not entity:
            raise ValueError(f"Entity {id} not found for deletion")
        return entity