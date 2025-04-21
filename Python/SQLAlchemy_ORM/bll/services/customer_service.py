from dal.repositories.customer_repository import CustomerRepository
from dal.data.database import SessionLocal
from dal.entities.customer import Customer

class CustomerService:
    def __init__(self):
        self.db = SessionLocal()
        self.repo = CustomerRepository(self.db)

    def get_by_id(self, id: str):
        entity = self.repo.get_by_id(id)
        if not entity:
            raise ValueError(f"Entity {id} not found")
        return entity

    def get_all(self):
        return self.repo.get_all()

    def create(self, entity: Customer) -> Customer:
        return self.repo.create(entity)

    def update(self, id: str, entity: Customer) -> Customer:
        entity = self.repo.update(id, entity)
        if not entity:
            raise ValueError(f"Entity {id} not found for update")
        return entity

    def delete(self, id: int):
        entity = self.repo.delete(id)
        if not entity:
            raise ValueError(f"Entity {id} not found for deletion")
        return entity