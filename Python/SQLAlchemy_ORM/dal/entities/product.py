from sqlalchemy import Column, Float, ForeignKey, Integer, SmallInteger, String, Text
from sqlalchemy.orm import relationship
from dal.data.base import Base

class Product(Base):
    __tablename__ = 'Products'

    ProductID = Column(Integer, primary_key=True)
    ProductName = Column(String(40))
    SupplierID = Column(Integer, ForeignKey('Suppliers.SupplierID'))
    CategoryID = Column(Integer, ForeignKey('Categories.CategoryID'))
    QuantityPerUnit = Column(String(20))
    UnitPrice = Column(Float)
    UnitsInStock = Column(SmallInteger, default=0)
    UnitsOnOrder = Column(SmallInteger, default=0)
    ReorderLevel = Column(SmallInteger, default=0)
    Discontinued = Column(SmallInteger, default=0)

    # Relationships with Category and Supplier
    category = relationship('Category', back_populates='products')
    supplier = relationship('Supplier', back_populates='products')

    # Relationship with OrderDetails
    order_details = relationship('OrderDetail', back_populates='product')