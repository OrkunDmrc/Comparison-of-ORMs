package entities

type EmployeeTerritory struct {
	EmployeeID  int    `gorm:"primaryKey;column:EmployeeID"`
	TerritoryID string `gorm:"primaryKey;size:20;column:TerritoryID"`
	Employee    Employee
	Territory   Territory
}
