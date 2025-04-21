from sqlalchemy import Column, DateTime, ForeignKey, Integer, String, Text
from sqlalchemy.orm import relationship
from dal.data.base import Base

class Employee(Base):
    __tablename__ = 'Employees'

    EmployeeID = Column(Integer, primary_key=True)
    LastName = Column(String(20))
    FirstName = Column(String(10))
    Title = Column(String(30))
    TitleOfCourtesy = Column(String(25))
    BirthDate = Column(DateTime)
    HireDate = Column(DateTime)
    Address = Column(String(60))
    City = Column(String(15))
    Region = Column(String(15))
    PostalCode = Column(String(10))
    Country = Column(String(15))
    HomePhone = Column(String(24))
    Extension = Column(String(4))
    Notes = Column(Text)
    Photo = Column(String)
    PhotoPath = Column(String(255))

    reports_to = Column(Integer, ForeignKey('Employees.EmployeeID'))
    #reports_to_navigation = relationship('Employee', remote_side=[Employee.EmployeeID], backref='inverse_reports_to_navigation')
    territories = relationship('Territory', secondary='EmployeeTerritories', back_populates='employees')
    orders = relationship('Order', back_populates='employee')