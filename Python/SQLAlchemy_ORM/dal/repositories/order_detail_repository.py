from sqlalchemy.orm import Session
from sqlalchemy import select, and_
from typing import List, Optional
from dal.entities.order_detail import OrderDetail  # Update this to your actual path

class OrderDetailRepository:
    def __init__(self, db: Session):
        self.db = db

    def get_all(self) -> List[OrderDetail]:
        result = self.db.execute(select(OrderDetail))
        return result.scalars().all()

    def get_by_id(self, order_id: int, product_id: int) -> Optional[OrderDetail]:
        result = self.db.execute(
            select(OrderDetail).where(
                and_(
                    OrderDetail.OrderID == order_id,
                    OrderDetail.ProductID == product_id
                )
            )
        )
        return result.scalar_one_or_none()

    def create(self, entity: OrderDetail) -> OrderDetail:
        self.db.add(entity)
        self.db.commit()
        self.db.refresh(entity)
        return entity

    def delete(self, order_id: int, product_id: int) -> Optional[OrderDetail]:
        entity = self.get_by_id(order_id, product_id)
        if entity:
            self.db.delete(entity)
            self.db.commit()
        return entity
