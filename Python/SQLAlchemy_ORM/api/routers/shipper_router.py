from fastapi import APIRouter, Depends, HTTPException
from dal.entities.shipper import Shipper
from bll.services.shipper_service import ShipperService

router = APIRouter(prefix="/shippers", tags=["shippers"])

@router.get("/{id}")
def get(id: int, svc: ShipperService = Depends(ShipperService)):
    try:
        return svc.get_by_id(id)
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.get("/")
def get_all(svc: ShipperService = Depends(ShipperService)):
    try:
        return svc.get_all()
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.post("/")
def add(entity: dict, svc: ShipperService = Depends(ShipperService)):
    try:
        return svc.create(Shipper(**entity))
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.put("/{id}")
def update(id: int, entity: dict, svc: ShipperService = Depends(ShipperService)):
    try:
        return svc.update(id, Shipper(**entity))
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.delete("/{id}")
def delete(id: int, svc: ShipperService = Depends(ShipperService)):
    try:
        return svc.delete(id)
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    


