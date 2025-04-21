from fastapi import APIRouter, Depends, HTTPException
from dal.entities.region import Region
from bll.services.region_service import RegionService

router = APIRouter(prefix="/regions", tags=["regions"])

@router.get("/{id}")
def get(id: int, svc: RegionService = Depends(RegionService)):
    try:
        return svc.get_by_id(id)
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.get("/")
def get_all(svc: RegionService = Depends(RegionService)):
    try:
        return svc.get_all()
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.post("/")
def add(entity: dict, svc: RegionService = Depends(RegionService)):
    try:
        return svc.create(Region(**entity))
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.put("/{id}")
def update(id: int, entity: dict, svc: RegionService = Depends(RegionService)):
    try:
        return svc.update(id, Region(**entity))
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.delete("/{id}")
def delete(id: int, svc: RegionService = Depends(RegionService)):
    try:
        return svc.delete(id)
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    


