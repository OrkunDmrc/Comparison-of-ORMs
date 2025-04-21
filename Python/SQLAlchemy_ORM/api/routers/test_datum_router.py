from fastapi import APIRouter, Depends, HTTPException
from dal.entities.test_datum import TestDatum
from bll.services.test_datum_service import TestDatumService

router = APIRouter(prefix="/testdata", tags=["testdata"])

@router.get("/")
def get_all(svc: TestDatumService = Depends(TestDatumService)):
    try:
        return svc.get_all()
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

    


