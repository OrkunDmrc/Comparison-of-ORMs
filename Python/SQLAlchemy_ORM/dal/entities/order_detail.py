from sqlalchemy import Column, Float, ForeignKey, Integer, SmallInteger, String, Text
from sqlalchemy.orm import relationship
from dal.data.base import Base

class OrderDetail(Base):
    __tablename__ = 'Order Details'

    OrderID = Column(Integer, ForeignKey('Orders.OrderID'), primary_key=True)
    ProductID = Column(Integer, ForeignKey('Products.ProductID'), primary_key=True)
    Quantity = Column(SmallInteger, default=1)
    UnitPrice = Column(Float)
    Discount = Column(Float)

    # Relationships with Order and Product
    order = relationship('Order', back_populates='order_details')
    product = relationship('Product', back_populates='order_details')