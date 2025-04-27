package entities

import "time"

type Order struct {
	OrderID        int           `gorm:"primaryKey;autoIncrement;column:OrderID"`
	CustomerID     *string       `gorm:"size:5;column:CustomerID"`
	EmployeeID     *int          `gorm:"column:EmployeeID"`
	OrderDate      *time.Time    `gorm:"column:OrderDate"`
	RequiredDate   *time.Time    `gorm:"column:RequiredDate"`
	ShippedDate    *time.Time    `gorm:"column:ShippedDate"`
	ShipVia        *int          `gorm:"column:ShipVia"`
	Freight        *float64      `gorm:"type:money;default:0;column:Freight"`
	ShipName       *string       `gorm:"size:40;column:ShipName"`
	ShipAddress    *string       `gorm:"size:60;column:ShipAddress"`
	ShipCity       *string       `gorm:"size:15;column:ShipCity"`
	ShipRegion     *string       `gorm:"size:15;column:ShipRegion"`
	ShipPostalCode *string       `gorm:"size:10;column:ShipPostalCode"`
	ShipCountry    *string       `gorm:"size:15;column:ShipCountry"`
	OrderDetails   []OrderDetail `gorm:"foreignKey:OrderID"`
	Customer       *Customer     `gorm:"foreignKey:CustomerID"`
	Employee       *Employee     `gorm:"foreignKey:EmployeeID"`
	Shipper        *Shipper      `gorm:"foreignKey:ShipVia"`
}
