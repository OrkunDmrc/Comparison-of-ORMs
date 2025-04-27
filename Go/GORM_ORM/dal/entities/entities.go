package entities

type Sysdiagram struct {
	DiagramID   int    `gorm:"primaryKey;autoIncrement;column:DiagramID"`
	Name        string `gorm:"size:128;column:Name"`
	PrincipalID int    `gorm:"column:PrincipalID"`
	Version     *int   `gorm:"column:Version"`
	Definition  *[]byte
}
