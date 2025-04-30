from dal.repositories.order_repository import OrderRepository
from dal.repositories.test_datum_repository import TestDatumRepository
from dal.data.database import SessionLocal
from dal.entities.order import Order

class OrderService:
    def __init__(self):
        self.db = SessionLocal()
        self.repo = OrderRepository(self.db)

    def get_by_id(self, id: int):
        return self.repo.get_by_id(id)

    def get_all(self):
        return self.repo.get_all()

    def create(self, entity: Order) -> Order:
        return self.repo.create(entity)
    
    def update(self, id: int, entity: Order) -> Order:
        return self.repo.update(id, entity)

    def delete(self, id: int):
        return self.repo.delete(id)