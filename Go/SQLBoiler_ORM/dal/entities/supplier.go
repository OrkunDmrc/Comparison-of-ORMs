package entities

type Supplier struct {
	SupplierID   int     `db:"SupplierID"`
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
	HomePage     *string `db:"HomePage"`
}
