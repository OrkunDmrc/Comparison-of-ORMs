from fastapi import APIRouter, Depends, HTTPException
from dal.entities.order_detail import OrderDetail
from bll.services.order_detail_service import OrderDetailService

router = APIRouter(prefix="/orderdetails", tags=["orderdetails"])

@router.get("/orderId={order_id}&productId={product_id}")
def get(order_id: int, product_id: int, svc: OrderDetailService = Depends(OrderDetailService)):
    try:
        return svc.get_by_id(order_id, product_id)
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.get("/")
def get_all(svc: OrderDetailService = Depends(OrderDetailService)):
    try:
        return svc.get_all()
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.post("/")
def add(entity: dict, svc: OrderDetailService = Depends(OrderDetailService)):
    try:
        return svc.create(OrderDetail(**entity))
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
    
@router.delete("/orderId={order_id}&productId={product_id}")
def delete(order_id: int, product_id: int, svc: OrderDetailService = Depends(OrderDetailService)):
    try:
        return svc.delete(order_id, product_id)
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    


