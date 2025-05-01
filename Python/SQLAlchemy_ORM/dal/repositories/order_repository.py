import time
from typing import List, Optional, Type
from sqlalchemy import select, text
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
        db_obj = self.db.get(Order, id)
        for key, value in obj.__dict__.items():
            if value is not None and key != "_sa_instance_state":
                setattr(db_obj, key, value)
        self.db.commit()
        self.db.refresh(db_obj)
        end_time = time.time()
        test_datum = TestDatum()
        test_datum.Language = "Python"
        test_datum.TestName = "SQLAlchemy Update Operation"
        test_datum.Performance = f"{(end_time - start_time) * 1000:.4f} ms"
        test_datum.MemoryUsage = f"{0} MB"
        test_datum.CpuUsage = f"{0} ms"
        self.test_datum_repo.create(test_datum)
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
    
    def allTables(self):
        stmt = text("""
            SELECT o.*, e.*, c.*, s.*, od.*, p.*, ct.*, sp.*, et.*, t.*, r.*
            FROM Orders o
            JOIN Employees e ON e.EmployeeID = o.EmployeeID
            JOIN Customers c ON c.CustomerID = o.CustomerID
            JOIN Shippers s ON s.ShipperID = o.ShipVia
            JOIN [Order Details] od ON od.OrderID = o.OrderID
            JOIN Products p ON p.ProductID = od.ProductID
            JOIN Categories ct ON ct.CategoryID = p.CategoryID
            JOIN Suppliers sp ON sp.SupplierID = p.SupplierID
            JOIN EmployeeTerritories et ON et.EmployeeID = e.EmployeeID
            JOIN Territories t ON t.TerritoryID = et.TerritoryID
            JOIN Region r ON r.RegionID = t.RegionID
        """)
        start_time = time.time()
        result = self.db.execute(stmt).fetchall()
        end_time = time.time()
        test_datum = TestDatum()
        test_datum.Language = "Python"
        test_datum.TestName = "SQLAlchemy All Tables Operation"
        test_datum.Performance = f"{(end_time - start_time) * 1000:.4f} ms"
        test_datum.MemoryUsage = f"{0} MB"
        test_datum.CpuUsage = f"{0} ms"
        self.test_datum_repo.create(test_datum)
