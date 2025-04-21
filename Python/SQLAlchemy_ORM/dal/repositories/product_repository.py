from sqlalchemy.orm import Session
from dal.entities.product import Product
from dal.repositories.generic_repository import GenericRepository

class ProductRepository(GenericRepository[Product, int]):
    def __init__(self, db: Session):
        super().__init__(Product, db)