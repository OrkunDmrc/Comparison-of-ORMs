from sqlalchemy.orm import Session
from dal.entities.test_datum import TestDatum
from dal.repositories.generic_repository import GenericRepository

class TestDatumRepository(GenericRepository[TestDatum, int]):
    def __init__(self, db: Session):
        super().__init__(TestDatum, db)