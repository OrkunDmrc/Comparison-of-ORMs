package entities

type Customer struct {
	CustomerID   string  `gorm:"primaryKey;size:5;column:CustomerID"`
	CompanyName  string  `gorm:"size:40;column:CompanyName"`
	ContactName  *string `gorm:"size:30;column:ContactName"`
	ContactTitle *string `gorm:"size:30;column:ContactTitle"`
	Address      *string `gorm:"size:60;column:Address"`
	City         *string `gorm:"size:15;index:City;column:City"`
	Region       *string `gorm:"size:15;index:Region;column:Region"`
	PostalCode   *string `gorm:"size:10;index:PostalCode;column:PostalCode"`
	Country      *string `gorm:"size:15;column:Country"`
	Phone        *string `gorm:"size:24;column:Phone"`
	Fax          *string `gorm:"size:24;column:Fax"`
	Orders       []Order `gorm:"foreignKey:CustomerID"`
}
