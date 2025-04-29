package entities

type TestData struct {
	ID          int     `db:"Id"`
	TestName    *string `db:"TestName"`
	CpuUsage    *string `db:"CpuUsage"`
	MemoryUsage *string `db:"MemoryUsage"`
	Performance *string `db:"Performance"`
	Language    *string `db:"Language"`
}

func (TestData) TableName() string {
	return "TestData"
}
