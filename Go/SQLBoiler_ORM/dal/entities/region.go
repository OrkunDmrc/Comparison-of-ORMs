package entities

type Region struct {
	RegionID          int    `db:"RegionID"`
	RegionDescription string `db:"RegionDescription"`
}

func (o *Region) TableName() string {
	return "region"
}
