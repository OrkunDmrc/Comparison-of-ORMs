from sqlalchemy.orm import Session
from dal.entities.employee import Employee
from dal.repositories.generic_repository import GenericRepository

class EmployeeRepository(GenericRepository[Employee, int]):
    def __init__(self, db: Session):
        super().__init__(Employee, db)