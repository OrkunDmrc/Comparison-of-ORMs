from sqlalchemy.ext.asyncio import AsyncSession
from dal.entities.category import Category
from dal.repositories.generic_repository import GenericRepository

class CategoryRepository(GenericRepository[Category, int]):
    def __init__(self, db: AsyncSession):
        super().__init__(Category, db)