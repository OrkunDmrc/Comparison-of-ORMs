from sqlalchemy import Column, ForeignKey, Integer, String
from dal.data.base import Base
class EmployeeTerritory(Base):
    __tablename__ = 'EmployeeTerritories'

    EmployeeID = Column(Integer, ForeignKey('Employees.EmployeeID'), primary_key=True)
    TerritoryID = Column(String(20), ForeignKey('Territories.TerritoryID'), primary_key=True)