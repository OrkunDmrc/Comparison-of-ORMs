from sqlalchemy import Column, ForeignKey, Integer, String
from sqlalchemy.orm import relationship
from dal.data.base import Base

class Territory(Base):
    __tablename__ = 'Territories'

    TerritoryID = Column(String(20), primary_key=True)
    TerritoryDescription = Column(String(50))
    RegionID = Column(Integer, ForeignKey('Region.RegionID'))

    region = relationship('Region', back_populates='territories')
    employees = relationship('Employee', secondary='EmployeeTerritories', back_populates='territories')