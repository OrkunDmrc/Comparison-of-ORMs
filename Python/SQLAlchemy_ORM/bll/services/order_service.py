from dal.repositories.order_repository import OrderRepository
from dal.repositories.test_datum_repository import TestDatumRepository
from dal.data.database import SessionLocal
from dal.entities.order import Order
from dal.entities.test_datum import TestDatum
import time
import psutil

class OrderService:
    def __init__(self):
        self.db = SessionLocal()
        self.repo = OrderRepository(self.db)
        self.test_datum_repo = TestDatumRepository(SessionLocal())

    def get_by_id(self, id: int):
        process = psutil.Process()
        cpu_before = process.cpu_times()
        mem_before = process.memory_info().rss
        start_time = time.time()

        entity = self.repo.get_by_id(id)
        if not entity:
            raise ValueError(f"Entity {id} not found")
        
        end_time = time.time()
        cpu_after = process.cpu_times()
        mem_after = process.memory_info().rss
        test_datum = TestDatum()
        test_datum.language = "Python"
        test_datum.test_name = "SQLAlchemy Get Operation"
        test_datum.performance = f"{(end_time - start_time) * 1000:.2f} ms"
        test_datum.memory_usage = f"{(mem_after - mem_before) / 1024 / 1024:.2f} MB"
        test_datum.cpu_usage = f"{(cpu_after.user - cpu_before.user) * 1000:.2f} ms"
        self.test_datum_repo.create(test_datum)

        return entity

    def get_all(self):
        process = psutil.Process()
        cpu_before = process.cpu_times()
        mem_before = process.memory_info().rss
        start_time = time.time()

        entities = self.repo.get_all()

        end_time = time.time()
        cpu_after = process.cpu_times()
        mem_after = process.memory_info().rss
        test_datum = TestDatum()
        test_datum.Language = "Python"
        test_datum.TestName = "SQLAlchemy Get All Operation"
        test_datum.Performance = f"{(end_time - start_time) * 1000:.2f} ms"
        test_datum.MemoryUsage = f"{(mem_after - mem_before) / 1024 / 1024:.2f} MB"
        test_datum.CpuUsage = f"{(cpu_after.user - cpu_before.user) * 1000:.2f} ms"
        self.test_datum_repo.create(test_datum)

        return entities

    def create(self, entity: Order) -> Order:
        process = psutil.Process()
        cpu_before = process.cpu_times()
        mem_before = process.memory_info().rss
        start_time = time.time()

        entity = self.repo.create(entity)

        end_time = time.time()
        cpu_after = process.cpu_times()
        mem_after = process.memory_info().rss
        test_datum = TestDatum()
        test_datum.Language = "Python"
        test_datum.TestName = "SQLAlchemy Create Operation"
        test_datum.Performance = f"{(end_time - start_time) * 1000:.2f} ms"
        test_datum.MemoryUsage = f"{(mem_after - mem_before) / 1024 / 1024:.2f} MB"
        test_datum.CpuUsage = f"{(cpu_after.user - cpu_before.user) * 1000:.2f} ms"
        self.test_datum_repo.create(test_datum)

        return entity
    
    def update(self, id: int, entity: Order) -> Order:
        process = psutil.Process()
        cpu_before = process.cpu_times()
        mem_before = process.memory_info().rss
        start_time = time.time()

        entity = self.repo.update(id, entity)
        if not entity:
            raise ValueError(f"Entity {id} not found for update")
        
        end_time = time.time()
        cpu_after = process.cpu_times()
        mem_after = process.memory_info().rss
        test_datum = TestDatum()
        test_datum.Language = "Python"
        test_datum.TestName = "SQLAlchemy Update Operation"
        test_datum.Performance = f"{(end_time - start_time) * 1000:.2f} ms"
        test_datum.MemoryUsage = f"{(mem_after - mem_before) / 1024 / 1024:.2f} MB"
        test_datum.CpuUsage = f"{(cpu_after.user - cpu_before.user) * 1000:.2f} ms"
        self.test_datum_repo.create(test_datum)

        return entity

    def delete(self, id: int):
        process = psutil.Process()
        cpu_before = process.cpu_times()
        mem_before = process.memory_info().rss
        start_time = time.time()

        entity = self.repo.delete(id)
        if not entity:
            raise ValueError(f"Entity {id} not found for deletion")
        
        end_time = time.time()
        cpu_after = process.cpu_times()
        mem_after = process.memory_info().rss
        test_datum = TestDatum()
        test_datum.Language = "Python"
        test_datum.TestName = "SQLAlchemy Delete Operation"
        test_datum.Performance = f"{(end_time - start_time) * 1000:.2f} ms"
        test_datum.MemoryUsage = f"{(mem_after - mem_before) / 1024 / 1024:.2f} MB"
        test_datum.CpuUsage = f"{(cpu_after.user - cpu_before.user) * 1000:.2f} ms"
        self.test_datum_repo.create(test_datum)

        return entity