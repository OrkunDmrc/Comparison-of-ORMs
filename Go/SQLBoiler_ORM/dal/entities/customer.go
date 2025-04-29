package entities

type Customer struct {
	CustomerID   string  `db:"CustomerID"`
	CompanyName  string  `db:"CompanyName"`
	ContactName  *string `db:"ContactName"`
	ContactTitle *string `db:"ContactTitle"`
	Address      *string `db:"Address"`
	City         *string `db:"City"`
	Region       *string `db:"Region"`
	PostalCode   *string `db:"PostalCode"`
	Country      *string `db:"Country"`
	Phone        *string `db:"Phone"`
	Fax          *string `db:"Fax"`
}
