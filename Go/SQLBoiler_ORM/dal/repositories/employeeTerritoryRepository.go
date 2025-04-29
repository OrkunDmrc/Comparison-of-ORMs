package repositories

import (
	"SQLBOILER_ORM/dal/entities"
	"context"
	"database/sql"
	"errors"
)

type EmployeeTerritoryRepository struct {
	db *sql.DB
}

func NewEmployeeTerritoryRepository(db *sql.DB) *EmployeeTerritoryRepository {
	return &EmployeeTerritoryRepository{db: db}
}

func (r *EmployeeTerritoryRepository) Create(ctx context.Context, employeeTerritory *entities.EmployeeTerritory) (*entities.EmployeeTerritory, error) {
	query := `INSERT INTO EmployeeTerritories (EmployeeID, TerritoryID) VALUES (@p1, @p2)`
	_, execErr := r.db.ExecContext(ctx, query, employeeTerritory.EmployeeID, employeeTerritory.TerritoryID)
	if execErr != nil {
		return nil, execErr
	}
	return employeeTerritory, nil
}

func (r *EmployeeTerritoryRepository) GetByEmployeeIDAndTerritoryID(ctx context.Context, employeeID int, territoryID string) (*entities.EmployeeTerritory, error) {
	query := `SELECT EmployeeID, TerritoryID FROM EmployeeTerritories WHERE EmployeeID = @p1 AND TerritoryID = @p2`
	row := r.db.QueryRowContext(ctx, query, employeeID, territoryID)
	var employeeTerritory entities.EmployeeTerritory
	err := row.Scan(&employeeTerritory.EmployeeID, &employeeTerritory.TerritoryID)
	if err != nil {
		if errors.Is(err, sql.ErrNoRows) {
			return nil, nil
		}
		return nil, err
	}
	return &employeeTerritory, nil
}

func (r *EmployeeTerritoryRepository) Delete(ctx context.Context, employeeID int, territoryID string) error {
	query := `DELETE FROM EmployeeTerritories WHERE EmployeeID = @p1 AND TerritoryID = @p2`
	_, err := r.db.ExecContext(ctx, query, employeeID, territoryID)
	return err
}

func (r *EmployeeTerritoryRepository) GetAll(ctx context.Context) ([]*entities.EmployeeTerritory, error) {
	query := `SELECT EmployeeID, TerritoryID FROM EmployeeTerritories`
	rows, err := r.db.QueryContext(ctx, query)
	if err != nil {
		return nil, err
	}
	defer rows.Close()

	var employeeTerritories []*entities.EmployeeTerritory
	for rows.Next() {
		var employeeTerritory entities.EmployeeTerritory
		if err := rows.Scan(&employeeTerritory.EmployeeID, &employeeTerritory.TerritoryID); err != nil {
			return nil, err
		}
		employeeTerritories = append(employeeTerritories, &employeeTerritory)
	}
	return employeeTerritories, nil
}
