package entities

type OrderDetail struct {
	OrderID   int     `gorm:"primaryKey;column:OrderID"`
	ProductID int     `gorm:"primaryKey;column:ProductID"`
	UnitPrice float64 `gorm:"type:money;default:0;column:UnitPrice"`
	Quantity  int     `gorm:"default:1;column:Quantity"`
	Discount  float64 `gorm:"default:0;column:Discount"`
	Order     Order   `gorm:"foreignKey:OrderID"`
	Product   Product `gorm:"foreignKey:ProductID"`
}

func (OrderDetail) TableName() string {
	return "Order Details"
}
