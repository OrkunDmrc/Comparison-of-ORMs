import base64
from fastapi import APIRouter, Depends, HTTPException
from dal.entities.category import Category
from bll.services.category_service import CategoryService

router = APIRouter(prefix="/categories", tags=["categories"])

@router.get("/{id}")
def get(id: int, svc: CategoryService = Depends(CategoryService)):
    try:
        entity = svc.get_by_id(id)
        entity.Picture = base64.b64encode(entity.Picture).decode("utf-8")
        return entity
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.get("/")
def get_all(svc: CategoryService = Depends(CategoryService)):
    try:
        entities = svc.get_all()
        for entity in entities:
            entity.Picture = base64.b64encode(entity.Picture).decode("utf-8")
        return entities
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.post("/")
def add(entity: dict, svc: CategoryService = Depends(CategoryService)):
    try:
        category = Category(**entity)
        entity = svc.create(category)
        entity.Picture = base64.b64encode(entity.Picture).decode("utf-8")
        return entity
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.put("/{id}")
def update(id: int, entity: dict, svc: CategoryService = Depends(CategoryService)):
    try:
        category = Category(**entity)
        entity = svc.update(id, category)
        entity.Picture = base64.b64encode(entity.Picture).decode("utf-8")
        return entity
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.delete("/{id}")
def delete(id: int, svc: CategoryService = Depends(CategoryService)):
    try:
        entity = svc.delete(id)
        entity.Picture = base64.b64encode(entity.Picture).decode("utf-8")
        return entity
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    


