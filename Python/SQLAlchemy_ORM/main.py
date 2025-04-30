from fastapi import FastAPI
from dal.data.database import init_db
from api.routers.category_router import router as category_router
from api.routers.customer_router import router as customer_router
from api.routers.employee_router import router as employee_router
from api.routers.employee_territory_router import router as employee_territory_router
from api.routers.order_detail_router import router as order_detail_router
from api.routers.order_router import router as order_router
from api.routers.product_router import router as product_router
from api.routers.region_router import router as region_router
from api.routers.shipper_router import router as shipper_router
from api.routers.supplier_router import router as supplier_router
from api.routers.territory_router import router as territory_router
from api.routers.test_datum_router import router as test_Datum_router
from contextlib import asynccontextmanager

@asynccontextmanager
async def lifespan(app: FastAPI):
    print("Starting up!")
    yield
    print("Shutting down!")

app = FastAPI(lifespan=lifespan)

init_db()

"""app = FastAPI()

@app.on_event("startup")
def startup():
    init_db()"""
#uvicorn main:app --reload
app.include_router(category_router)
app.include_router(customer_router)
app.include_router(employee_router)
app.include_router(employee_territory_router)
app.include_router(order_detail_router)
app.include_router(order_router)
app.include_router(product_router)
app.include_router(region_router)
app.include_router(shipper_router)
app.include_router(supplier_router)
app.include_router(territory_router)
app.include_router(test_Datum_router)

@app.get("/")
def read_root():
    return {"message": "FastAPI is working!"}