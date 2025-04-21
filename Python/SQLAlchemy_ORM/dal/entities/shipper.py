from sqlalchemy import Column, Integer, String
from sqlalchemy.orm import relationship
from dal.data.base import Base

class Shipper(Base):
    __tablename__ = 'Shippers'

    ShipperID = Column(Integer, primary_key=True)
    CompanyName = Column(String(40))
    Phone = Column(String(24))

    # Relationship with Orders
    orders = relationship('Order', back_populates='shipper')