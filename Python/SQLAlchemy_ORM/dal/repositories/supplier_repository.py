from sqlalchemy.orm import Session
from dal.entities.supplier import Supplier
from dal.repositories.generic_repository import GenericRepository

class SupplierRepository(GenericRepository[Supplier, int]):
    def __init__(self, db: Session):
        super().__init__(Supplier, db)