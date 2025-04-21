import base64
from fastapi import APIRouter, Depends, HTTPException
from dal.entities.employee import Employee
from bll.services.employee_service import EmployeeService

router = APIRouter(prefix="/employees", tags=["employees"])

@router.get("/{id}")
def get(id: int, svc: EmployeeService = Depends(EmployeeService)):
    try:
        entity = svc.get_by_id(id)
        entity.Photo = base64.b64encode(entity.Photo).decode("utf-8")
        return entity
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.get("/")
def get_all(svc: EmployeeService = Depends(EmployeeService)):
    try:
        entities = svc.get_all()
        for entity in entities:
            entity.Photo = base64.b64encode(entity.Photo).decode("utf-8")
        return entities
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.post("/")
def add(entity: dict, svc: EmployeeService = Depends(EmployeeService)):
    try:
        employee = Employee(**entity)
        entity = svc.create(employee)
        entity.Photo = base64.b64encode(entity.Photo).decode("utf-8")
        return entity
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.put("/{id}")
def update(id: int, entity: dict, svc: EmployeeService = Depends(EmployeeService)):
    try:
        employee = Employee(**entity)
        entity = svc.update(id, employee)
        entity.Photo = base64.b64encode(entity.Photo).decode("utf-8")
        return entity
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.delete("/{id}")
def delete(id: int, svc: EmployeeService = Depends(EmployeeService)):
    try:
        entity = svc.delete(id)
        entity.Photo = base64.b64encode(entity.Photo).decode("utf-8")
        return entity
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    


