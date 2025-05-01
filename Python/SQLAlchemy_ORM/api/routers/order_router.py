from fastapi import APIRouter, Depends, HTTPException
from dal.entities.order import Order
from bll.services.order_service import OrderService

router = APIRouter(prefix="/orders", tags=["orders"])

@router.get("/AllTables")
def get_all(svc: OrderService = Depends(OrderService)):
    try:
        for i in range(20):
            svc.allTables()
        return "OK"
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.get("/{id}")
def get(id: int, svc: OrderService = Depends(OrderService)):
    try:
        for i in range(19):
            svc.get_by_id(id)
        return svc.get_by_id(id)
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.get("/")
def get_all(svc: OrderService = Depends(OrderService)):
    try:
        for i in range(19):
            svc.get_all()
        return svc.get_all()
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.post("/")
def add(entity: dict, svc: OrderService = Depends(OrderService)):
    try:
        for i in range(19):
            svc.create(Order(**entity))
        return svc.create(Order(**entity))
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.put("/{id}")
def update(id: int, entity: dict, svc: OrderService = Depends(OrderService)):
    try:
        for i in range(20):
            svc.update(id, Order(**entity))
        return "OK"
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.delete("/{id}")
def delete(id: int, svc: OrderService = Depends(OrderService)):
    try:
        for i in range(20):
            svc.delete(id - i)
        return "OK"
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    


