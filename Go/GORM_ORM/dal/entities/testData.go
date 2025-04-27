package entities

type TestData struct {
	ID          int     `gorm:"primaryKey;autoIncrement;column:Id"`
	TestName    *string `gorm:"size:50;column:TestName"`
	CpuUsage    *string `gorm:"size:50;column:CpuUsage"`
	MemoryUsage *string `gorm:"size:50;column:MemoryUsage"`
	Performance *string `gorm:"size:50;column:Performance"`
	Language    *string `gorm:"size:50;column:Language"`
}

func (TestData) TableName() string {
	return "TestData"
}
