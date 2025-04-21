from sqlalchemy import Column, Integer, String
from sqlalchemy.orm import relationship
from dal.data.base import Base

class Region(Base):
    __tablename__ = 'Region'

    RegionID = Column(Integer, primary_key=True)
    RegionDescription = Column(String(50))

    territories = relationship('Territory', back_populates='region')