from sqlalchemy.orm import Session
from dal.entities.region import Region
from dal.repositories.generic_repository import GenericRepository

class RegionRepository(GenericRepository[Region, int]):
    def __init__(self, db: Session):
        super().__init__(Region, db)