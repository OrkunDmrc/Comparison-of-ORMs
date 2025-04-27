package entities

type Category struct {
	CategoryID   int       `gorm:"primaryKey;autoIncrement;column:CategoryID"`
	CategoryName string    `gorm:"size:15;index:CategoryName;column:CategoryName"`
	Description  *string   `gorm:"type:ntext;column:Description"`
	Picture      []byte    `gorm:"type:image;column:Picture"`
	Products     []Product `gorm:"foreignKey:CategoryID"`
}
