from sqlalchemy import Column, Integer, String, Text, LargeBinary, VARBINARY
from sqlalchemy.orm import relationship
from dal.data.base import Base

class Category(Base):
    __tablename__ = 'Categories'

    CategoryID = Column(Integer, primary_key=True, autoincrement=True)
    CategoryName = Column(String(15), nullable=False)
    Description = Column(Text)
    Picture = Column(String)

    products = relationship('Product', back_populates='category')