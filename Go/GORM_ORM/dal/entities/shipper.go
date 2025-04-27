package entities

type Shipper struct {
	ShipperID   int     `gorm:"primaryKey;autoIncrement;column:ShipperID"`
	CompanyName string  `gorm:"size:40;column:CompanyName"`
	Phone       *string `gorm:"size:24;column:Phone"`
	Orders      []Order `gorm:"foreignKey:ShipVia"`
}
