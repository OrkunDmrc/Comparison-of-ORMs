package entities

type SysDiagram struct {
	Name        string  `db:"name"`
	PrincipalID int     `db:"principal_id"`
	DiagramID   int     `db:"diagram_id"`
	Version     *int    `db:"version"`
	Definition  *[]byte `db:"definition"`
}
