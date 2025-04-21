from fastapi import APIRouter, Depends, HTTPException
from dal.entities.customer import Customer
from bll.services.customer_service import CustomerService

router = APIRouter(prefix="/customers", tags=["customers"])

@router.get("/{id}")
def get(id: int, svc: CustomerService = Depends(CustomerService)):
    try:
        return svc.get_by_id(id)
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.get("/")
def get_all(svc: CustomerService = Depends(CustomerService)):
    try:
        return svc.get_all()
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.post("/")
def add(entity: dict, svc: CustomerService = Depends(CustomerService)):
    try:
        return svc.create(Customer(**entity))
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.put("/{id}")
def update(id: int, entity: dict, svc: CustomerService = Depends(CustomerService)):
    try:
        return svc.update(id, Customer(**entity))
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.delete("/{id}")
def delete(id: int, svc: CustomerService = Depends(CustomerService)):
    try:
        return svc.delete(id)
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    


