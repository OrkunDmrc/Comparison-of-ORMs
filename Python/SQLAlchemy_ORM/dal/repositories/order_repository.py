from sqlalchemy.orm import Session
from dal.entities.order import Order
from dal.repositories.generic_repository import GenericRepository

class OrderRepository(GenericRepository[Order, int]):
    def __init__(self, db: Session):
        super().__init__(Order, db)