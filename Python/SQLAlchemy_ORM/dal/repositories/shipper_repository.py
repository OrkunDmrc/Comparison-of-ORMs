from sqlalchemy.orm import Session
from dal.entities.shipper import Shipper
from dal.repositories.generic_repository import GenericRepository

class ShipperRepository(GenericRepository[Shipper, int]):
    def __init__(self, db: Session):
        super().__init__(Shipper, db)