from sqlalchemy import Column, Integer, String, Text
from sqlalchemy.orm import relationship
from dal.data.base import Base

class Supplier(Base):
    __tablename__ = 'Suppliers'

    SupplierID = Column(Integer, primary_key=True)
    CompanyName = Column(String(40))
    ContactName = Column(String(30))
    ContactTitle = Column(String(30))
    Address = Column(String(60))
    City = Column(String(15))
    Region = Column(String(15))
    PostalCode = Column(String(10))
    Country = Column(String(15))
    Phone = Column(String(24))
    Fax = Column(String(24))
    HomePage = Column(Text)

    # Relationship with Products
    products = relationship('Product', back_populates='supplier')