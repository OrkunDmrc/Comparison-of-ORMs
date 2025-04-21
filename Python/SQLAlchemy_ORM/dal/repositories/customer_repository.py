from sqlalchemy.orm import Session
from dal.entities.customer import Customer
from dal.repositories.generic_repository import GenericRepository

class CustomerRepository(GenericRepository[Customer, str]):
    def __init__(self, db: Session):
        super().__init__(Customer, db)