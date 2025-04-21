from dal.repositories.order_detail_repository import OrderDetailRepository
from dal.data.database import SessionLocal
from dal.entities.order_detail import OrderDetail

class OrderDetailService:
    def __init__(self):
        self.db = SessionLocal()
        self.repo = OrderDetailRepository(self.db)

    def get_by_id(self, order_id: int, product_id: int) -> OrderDetail:
        entity = self.repo.get_by_id(order_id, product_id)
        if not entity:
            raise ValueError(f"Entity {order_id} and {product_id} not found")
        return entity

    def get_all(self):
        return self.repo.get_all()
    
    def create(self, entity: OrderDetail) -> OrderDetail:
        return self.repo.create(entity)

    def delete(self, order_id: int, product_id: int):
        entity = self.repo.delete(order_id, product_id)
        if not entity:
            raise ValueError(f"Entity {order_id} and {product_id} not found")
        return entity