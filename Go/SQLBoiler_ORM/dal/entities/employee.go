package entities

import "time"

type Employee struct {
	EmployeeID      int        `db:"EmployeeID"`
	LastName        string     `db:"LastName"`
	FirstName       string     `db:"FirstName"`
	Title           *string    `db:"Title"`
	TitleOfCourtesy *string    `db:"TitleOfCourtesy"`
	BirthDate       *time.Time `db:"BirthDate"`
	HireDate        *time.Time `db:"HireDate"`
	Address         *string    `db:"Address"`
	City            *string    `db:"City"`
	Region          *string    `db:"Region"`
	PostalCode      *string    `db:"PostalCode"`
	Country         *string    `db:"Country"`
	HomePhone       *string    `db:"HomePhone"`
	Extension       *string    `db:"Extension"`
	Photo           *[]byte    `db:"Photo"`
	Notes           *string    `db:"Notes"`
	ReportsTo       *int       `db:"ReportsTo"`
	PhotoPath       *string    `db:"PhotoPath"`
}
