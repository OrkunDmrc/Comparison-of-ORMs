package entities

type Territory struct {
	TerritoryID          string `gorm:"primaryKey;size:20;column:TerritoryID"`
	TerritoryDescription string `gorm:"size:50;column:TerritoryDescription"`
	RegionID             int    `gorm:"column:RegionID"`
	Region               Region `gorm:"foreignKey:RegionID"`
	EmployeeTerritories  []EmployeeTerritory
}
