from sqlalchemy.orm import Session
from dal.entities.territory import Territory
from dal.repositories.generic_repository import GenericRepository

class TerritoryRepository(GenericRepository[Territory, str]):
    def __init__(self, db: Session):
        super().__init__(Territory, db)