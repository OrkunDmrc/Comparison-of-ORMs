from fastapi import APIRouter, Depends, HTTPException
from dal.entities.territory import Territory
from bll.services.territory_service import TerritoryService

router = APIRouter(prefix="/territories", tags=["territories"])

@router.get("/{id}")
def get(id: int, svc: TerritoryService = Depends(TerritoryService)):
    try:
        return svc.get_by_id(id)
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.get("/")
def get_all(svc: TerritoryService = Depends(TerritoryService)):
    try:
        return svc.get_all()
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.post("/")
def add(entity: dict, svc: TerritoryService = Depends(TerritoryService)):
    try:
        return svc.create(Territory(**entity))
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.put("/{id}")
def update(id: int, entity: dict, svc: TerritoryService = Depends(TerritoryService)):
    try:
        return svc.update(id, Territory(**entity))
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.delete("/{id}")
def delete(id: int, svc: TerritoryService = Depends(TerritoryService)):
    try:
        return svc.delete(id)
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    


