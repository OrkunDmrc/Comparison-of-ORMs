from sqlalchemy import Column, Integer, String
from dal.data.base import Base

class TestDatum(Base):
    __tablename__ = 'TestData'

    TestID = Column(Integer, primary_key=True)
    TestName = Column(String(50))
    CpuUsage = Column(String(50))
    MemoryUsage = Column(String(50))
    Performance = Column(String(50))
    Language = Column(String(50))