package entities

import "time"

type Employee struct {
	EmployeeID      int        `gorm:"primaryKey;autoIncrement;column:EmployeeID"`
	LastName        string     `gorm:"size:20;index:LastName;column:LastName"`
	FirstName       string     `gorm:"size:10;column:FirstName"`
	Title           *string    `gorm:"size:30;column:Title"`
	TitleOfCourtesy *string    `gorm:"size:25;column:TitleOfCourtesy"`
	BirthDate       *time.Time `gorm:"column:BirthDate"`
	HireDate        *time.Time `gorm:"column:HireDate"`
	Address         *string    `gorm:"size:60;column:Address"`
	City            *string    `gorm:"size:15;column:City"`
	Region          *string    `gorm:"size:15;column:Region"`
	PostalCode      *string    `gorm:"size:10;index:PostalCode;column:PostalCode"`
	Country         *string    `gorm:"size:15;column:Country"`
	HomePhone       *string    `gorm:"size:24;column:HomePhone"`
	Extension       *string    `gorm:"size:4;column:Extension"`
	Photo           *[]byte    `gorm:"type:image;column:Photo"`
	Notes           *string    `gorm:"type:ntext;column:Notes"`
	ReportsTo       *int       `gorm:"column:ReportsTo"`
	PhotoPath       *string    `gorm:"size:255;column:PhotoPath"`
	Manager         *Employee  `gorm:"foreignKey:ReportsTo"`
	Subordinates    []Employee `gorm:"foreignKey:ReportsTo"`
	Territories     []EmployeeTerritory
	Orders          []Order `gorm:"foreignKey:EmployeeID"`
}
