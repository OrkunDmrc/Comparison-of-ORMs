package entities

type OrderDetail struct {
	OrderID   int     `db:"OrderID"`
	ProductID int     `db:"ProductID"`
	UnitPrice float64 `db:"UnitPrice"`
	Quantity  int     `db:"Quantity"`
	Discount  float64 `db:"Discount"`
}

func (OrderDetail) TableName() string {
	return "Order Details"
}
