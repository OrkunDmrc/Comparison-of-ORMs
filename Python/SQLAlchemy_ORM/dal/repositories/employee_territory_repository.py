from sqlalchemy.orm import Session
from dal.entities.employee_territory import EmployeeTerritory
from dal.repositories.generic_repository import GenericRepository

class EmployeeTerritoryRepository(GenericRepository[EmployeeTerritory, int]):
    def __init__(self, db: Session):
        super().__init__(EmployeeTerritory, db)