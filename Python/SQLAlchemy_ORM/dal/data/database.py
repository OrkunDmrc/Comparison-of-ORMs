import urllib.parse
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
from dal.data.base import Base

# Your raw ODBC connection string
odbc_str = (
    "Driver={ODBC Driver 17 for SQL Server};"
    "Server=ORKUN\\SQLEXPRESS;"
    "Database=NorthwindTest;"
    "UID=sa;"
    "PWD=123456;"
    "TrustServerCertificate=yes"
)

# URL‑encode the ODBC string
params = urllib.parse.quote_plus(odbc_str)

# Create engine using the mssql+pyodbc dialect and odbc_connect
engine = create_engine(
    f"mssql+pyodbc:///?odbc_connect={params}",
    echo=True
)

# Factory for DB sessions
SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)

def init_db():
    Base.metadata.create_all(bind=engine)