package entities

type Region struct {
	RegionID          int    `gorm:"primaryKey;column:RegionID"`
	RegionDescription string `gorm:"size:50;column:RegionDescription"`
	Territories       []Territory
}

func (Region) TableName() string {
	return "Region"
}
