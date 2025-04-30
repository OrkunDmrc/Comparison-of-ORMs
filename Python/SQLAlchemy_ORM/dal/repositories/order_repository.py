import time
from typing import List, Optional, Type
from sqlalchemy import select
from sqlalchemy.orm import Session
from dal.data.database import SessionLocal
from dal.entities.order import Order
from dal.entities.test_datum import TestDatum
from dal.repositories.test_datum_repository import TestDatumRepository

class OrderRepository():
    def __init__(self, db: Session):
        self.db = db
        self.test_datum_repo = TestDatumRepository(SessionLocal())

    def get_by_id(self, id: int) -> Order:
        start_time = time.time()
        entity = self.db.get(Order, id)
        end_time = time.time()
        test_datum = TestDatum()
        test_datum.Language = "Python"
        test_datum.TestName = "SQLAlchemy Get Operation"
        test_datum.Performance = f"{(end_time - start_time) * 1000:.4f} ms"
        test_datum.MemoryUsage = f"{0} MB"
        test_datum.CpuUsage = f"{0} ms"
        self.test_datum_repo.create(test_datum)
        return entity

    def get_all(self) -> List[Order]:
        start_time = time.time()
        entities = self.db.execute(select(Order))
        end_time = time.time()
        test_datum = TestDatum()
        test_datum.Language = "Python"
        test_datum.TestName = "SQLAlchemy Get All Operation"
        test_datum.Performance = f"{(end_time - start_time) * 1000:.4f} ms"
        test_datum.MemoryUsage = f"{0} MB"
        test_datum.CpuUsage = f"{0} ms"
        self.test_datum_repo.create(test_datum)
        return entities.scalars().all()
    
    def create(self, obj: Order) -> Order:
        start_time = time.time()
        self.db.add(obj)
        self.db.commit()
        end_time = time.time()
        self.db.refresh(obj)
        test_datum = TestDatum()
        test_datum.Language = "Python"
        test_datum.TestName = "SQLAlchemy Create Operation"
        test_datum.Performance = f"{(end_time - start_time) * 1000:.4f} ms"
        test_datum.MemoryUsage = f"{0} MB"
        test_datum.CpuUsage = f"{0} ms"
        self.test_datum_repo.create(test_datum)
        return obj

    def update(self, id: int, obj: Order) -> Optional[Order]:
        start_time = time.time()
        db_obj = self.get_by_id(id)
        self.db.commit()
        end_time = time.time()
        self.db.refresh(obj)
        test_datum = TestDatum()
        test_datum.Language = "Python"
        test_datum.TestName = "SQLAlchemy Update Operation"
        test_datum.Performance = f"{(end_time - start_time) * 1000:.4f} ms"
        test_datum.MemoryUsage = f"{0} MB"
        test_datum.CpuUsage = f"{0} ms"
        self.test_datum_repo.create(test_datum)
        self.db.refresh(db_obj)
        return db_obj

    def delete(self, id: int) -> Optional[Order]:
        start_time = time.time()
        db_obj = self.db.get(Order, id)
        self.db.delete(db_obj)
        self.db.commit()
        end_time = time.time()
        test_datum = TestDatum()
        test_datum.Language = "Python"
        test_datum.TestName = "SQLAlchemy Delete Operation"
        test_datum.Performance = f"{(end_time - start_time) * 1000:.4f} ms"
        test_datum.MemoryUsage = f"{0} MB"
        test_datum.CpuUsage = f"{0} ms"
        self.test_datum_repo.create(test_datum)
        return db_obj