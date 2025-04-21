from fastapi import APIRouter, Depends, HTTPException
from dal.entities.order import Order
from bll.services.order_service import OrderService

router = APIRouter(prefix="/orders", tags=["orders"])

@router.get("/{id}")
def get(id: int, svc: OrderService = Depends(OrderService)):
    try:
        return svc.get_by_id(id)
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.get("/")
def get_all(svc: OrderService = Depends(OrderService)):
    try:
        return svc.get_all()
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.post("/")
def add(entity: dict, svc: OrderService = Depends(OrderService)):
    try:
        return svc.create(Order(**entity))
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.put("/{id}")
def update(id: int, entity: dict, svc: OrderService = Depends(OrderService)):
    try:
        return svc.update(id, Order(**entity))
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.delete("/{id}")
def delete(id: int, svc: OrderService = Depends(OrderService)):
    try:
        return svc.delete(id)
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    


