from fastapi import APIRouter, Depends, HTTPException
from dal.entities.supplier import Supplier
from bll.services.supplier_service import SupplierService

router = APIRouter(prefix="/suppliers", tags=["suppliers"])

@router.get("/{id}")
def get(id: int, svc: SupplierService = Depends(SupplierService)):
    try:
        return svc.get_by_id(id)
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.get("/")
def get_all(svc: SupplierService = Depends(SupplierService)):
    try:
        return svc.get_all()
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.post("/")
def add(entity: dict, svc: SupplierService = Depends(SupplierService)):
    try:
        return svc.create(Supplier(**entity))
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.put("/{id}")
def update(id: int, entity: dict, svc: SupplierService = Depends(SupplierService)):
    try:
        return svc.update(id, Supplier(**entity))
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.delete("/{id}")
def delete(id: int, svc: SupplierService = Depends(SupplierService)):
    try:
        return svc.delete(id)
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    


