from fastapi import APIRouter, Depends, HTTPException
from dal.entities.employee_territory import EmployeeTerritory
from bll.services.employee_territory_service import EmployeeTerritoryService

router = APIRouter(prefix="/employeeterritories", tags=["employeeterritories"])

@router.get("/{id}")
def get(id: int, svc: EmployeeTerritoryService = Depends(EmployeeTerritoryService)):
    try:
        return svc.get_by_id(id)
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.get("/")
def get_all(svc: EmployeeTerritoryService = Depends(EmployeeTerritoryService)):
    try:
        return svc.get_all()
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

@router.post("/")
def add(entity: dict, svc: EmployeeTerritoryService = Depends(EmployeeTerritoryService)):
    try:
        return svc.create(EmployeeTerritory(**entity))
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.put("/{id}")
def update(id: int, entity: dict, svc: EmployeeTerritoryService = Depends(EmployeeTerritoryService)):
    try:
        return svc.update(id, EmployeeTerritory(**entity))
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    
@router.delete("/{id}")
def delete(id: int, svc: EmployeeTerritoryService = Depends(EmployeeTerritoryService)):
    try:
        return svc.delete(id)
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))
    


