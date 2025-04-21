from typing import TypeVar, Generic, Type, Optional, List
from sqlalchemy.orm import Session

ModelType = TypeVar('ModelType')
IDType = TypeVar('IDType')

class GenericRepository(Generic[ModelType, IDType]):
    def __init__(self, model: Type[ModelType], db: Session):
        self.model = model
        self.db = db

    def get_by_id(self, id: IDType) -> Optional[ModelType]:
        return self.db.query(self.model).get(id)

    def get_all(self) -> List[ModelType]:
        return self.db.query(self.model).all()

    def create(self, obj: ModelType) -> ModelType:
        self.db.add(obj)
        self.db.commit()
        self.db.refresh(obj)
        return obj

    def update(self, id: IDType, obj: ModelType) -> Optional[ModelType]:
        db_obj = self.get_by_id(id)
        if not db_obj:
            return None
        for key, value in obj.__dict__.items():
            if value is not None and key != "_sa_instance_state":
                setattr(db_obj, key, value)
        self.db.commit()
        self.db.refresh(db_obj)
        return db_obj

    def delete(self, id: IDType) -> Optional[ModelType]:
        db_obj = self.get_by_id(id)
        if not db_obj:
            return None
        self.db.delete(db_obj)
        self.db.commit()
        return db_obj
