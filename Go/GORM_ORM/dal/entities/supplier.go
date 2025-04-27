package entities

type Supplier struct {
	SupplierID   int       `gorm:"primaryKey;autoIncrement;column:SupplierID"`
	CompanyName  string    `gorm:"size:40;column:CompanyName"`
	ContactName  *string   `gorm:"size:30;column:ContactName"`
	ContactTitle *string   `gorm:"size:30;column:ContactTitle"`
	Address      *string   `gorm:"size:60;column:Address"`
	City         *string   `gorm:"size:15;column:City"`
	Region       *string   `gorm:"size:15;column:Region"`
	PostalCode   *string   `gorm:"size:10;column:PostalCode"`
	Country      *string   `gorm:"size:15;column:Country"`
	Phone        *string   `gorm:"size:24;column:Phone"`
	Fax          *string   `gorm:"size:24;column:Fax"`
	HomePage     *string   `gorm:"type:ntext;column:HomePage"`
	Products     []Product `gorm:"foreignKey:SupplierID"`
}
