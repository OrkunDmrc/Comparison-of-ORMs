package entities

type Territory struct {
	TerritoryID          string `db:"TerritoryID"`
	TerritoryDescription string `db:"TerritoryDescription"`
	RegionID             int    `db:"RegionID"`
}
