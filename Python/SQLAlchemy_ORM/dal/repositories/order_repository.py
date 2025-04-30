from typing import List, Optional, Type
from sqlalchemy import select
from sqlalchemy.orm import Session
from dal.entities.order import Order
from dal.repositories.generic_repository import GenericRepository

class OrderRepository():
    def __init__(self, db: Session):
        self.db = db

    def get_by_id(self, id: int) -> Order:
        return self.db.get(Order, id)

    def get_all(self) -> List[Order]:
        result = self.db.execute(select(Order))
        return result.scalars().all()
    
    def create(self, obj: Order) -> Order:
        self.db.add(obj)
        self.db.commit()
        self.db.refresh(obj)
        return obj

    def update(self, id: int, obj: Order) -> Optional[Order]:
        db_obj = self.get_by_id(id)
        if not db_obj:
            return None
        for key, value in obj.__dict__.items():
            if value is not None and key != "_sa_instance_state":
                setattr(db_obj, key, value)
        self.db.commit()
        self.db.refresh(db_obj)
        return db_obj

    def delete(self, id: int) -> Optional[Order]:
        db_obj = self.get_by_id(id)
        if not db_obj:
            return None
        self.db.delete(db_obj)
        self.db.commit()
        return db_obj