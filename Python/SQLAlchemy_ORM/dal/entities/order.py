from sqlalchemy import Column, DateTime, Float, ForeignKey, Integer, String
from sqlalchemy.orm import relationship
from dal.data.base import Base

class Order(Base):
    __tablename__ = 'Orders'

    OrderID = Column(Integer, primary_key=True)
    CustomerID = Column(String(5), ForeignKey('Customers.CustomerID'))
    EmployeeID = Column(Integer, ForeignKey('Employees.EmployeeID'))
    OrderDate = Column(DateTime)
    RequiredDate = Column(DateTime)
    ShippedDate = Column(DateTime)
    ShipVia = Column(Integer, ForeignKey('Shippers.ShipperID'))
    Freight = Column(Float)
    ShipName = Column(String(40))
    ShipAddress = Column(String(60))
    ShipCity = Column(String(15))
    ShipRegion = Column(String(15))
    ShipPostalCode = Column(String(10))
    ShipCountry = Column(String(15))

    customer = relationship('Customer', back_populates='orders')
    employee = relationship('Employee', back_populates='orders')
    shipper = relationship('Shipper', back_populates='orders')
    order_details = relationship('OrderDetail', back_populates='order')