package entities

type Shipper struct {
	ShipperID   int     `db:"ShipperID"`
	CompanyName string  `db:"CompanyName"`
	Phone       *string `db:"Phone"`
}
