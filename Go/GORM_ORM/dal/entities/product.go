package entities

type Product struct {
	ProductID       int           `gorm:"primaryKey;autoIncrement;column:ProductID"`
	ProductName     string        `gorm:"size:40;column:ProductName"`
	SupplierID      *int          `gorm:"column:SupplierID"`
	CategoryID      *int          `gorm:"column:CategoryID"`
	QuantityPerUnit *string       `gorm:"size:20;column:QuantityPerUnit"`
	UnitPrice       *float64      `gorm:"type:money;default:0;column:UnitPrice"`
	UnitsInStock    *int          `gorm:"default:0;column:UnitsInStock"`
	UnitsOnOrder    *int          `gorm:"default:0;column:UnitsOnOrder"`
	ReorderLevel    *int          `gorm:"default:0;column:ReorderLevel"`
	Discontinued    bool          `gorm:"default:false;column:Discontinued"`
	OrderDetails    []OrderDetail `gorm:"foreignKey:ProductID"`
	Category        *Category     `gorm:"foreignKey:CategoryID"`
	Supplier        *Supplier     `gorm:"foreignKey:SupplierID"`
}
