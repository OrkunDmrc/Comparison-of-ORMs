package entities

type Category struct {
	CategoryID   int     `db:"CategoryID"`
	CategoryName string  `db:"CategoryName"`
	Description  *string `db:"Description"`
	Picture      []byte  `db:"Picture"`
}
