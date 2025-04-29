package entities

type Product struct {
	ProductID       int      `db:"ProductID"`
	ProductName     string   `db:"ProductName"`
	SupplierID      *int     `db:"SupplierID"`
	CategoryID      *int     `db:"CategoryID"`
	QuantityPerUnit *string  `db:"QuantityPerUnit"`
	UnitPrice       *float64 `db:"UnitPrice"`
	UnitsInStock    *int     `db:"UnitsInStock"`
	UnitsOnOrder    *int     `db:"UnitsOnOrder"`
	ReorderLevel    *int     `db:"ReorderLevel"`
	Discontinued    bool     `db:"Discontinued"`
}
