package entities

import "time"

type Order struct {
	OrderID        int        `db:"OrderID"`
	CustomerID     *string    `db:"CustomerID"`
	EmployeeID     *int       `db:"EmployeeID"`
	OrderDate      *time.Time `db:"OrderDate"`
	RequiredDate   *time.Time `db:"RequiredDate"`
	ShippedDate    *time.Time `db:"ShippedDate"`
	ShipVia        *int       `db:"ShipVia"`
	Freight        *float64   `db:"Freight"`
	ShipName       *string    `db:"ShipName"`
	ShipAddress    *string    `db:"ShipAddress"`
	ShipCity       *string    `db:"ShipCity"`
	ShipRegion     *string    `db:"ShipRegion"`
	ShipPostalCode *string    `db:"ShipPostalCode"`
	ShipCountry    *string    `db:"ShipCountry"`
}
