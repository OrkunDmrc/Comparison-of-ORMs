package entities

type EmployeeTerritory struct {
	EmployeeID  int    `db:"EmployeeID"`
	TerritoryID string `db:"TerritoryID"`
}
