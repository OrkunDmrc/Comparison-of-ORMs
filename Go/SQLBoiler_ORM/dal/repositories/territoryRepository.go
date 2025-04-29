package repositories

import (
	"SQLBOILER_ORM/dal/entities"
	"context"
	"database/sql"
	"errors"
)

type TerritoryRepository struct {
	db *sql.DB
}

func NewTerritoryRepository(db *sql.DB) *TerritoryRepository {
	return &TerritoryRepository{db: db}
}

func (r *TerritoryRepository) Create(ctx context.Context, territory *entities.Territory) (*entities.Territory, error) {
	query := `INSERT INTO Territories (TerritoryID, TerritoryDescription, RegionID) VALUES (@p1, @p2, @p3)`
	_, execErr := r.db.ExecContext(ctx, query, territory.TerritoryID, territory.TerritoryDescription, territory.RegionID)
	if execErr != nil {
		return nil, execErr
	}
	return territory, nil
}

func (r *TerritoryRepository) GetByID(ctx context.Context, id string) (*entities.Territory, error) {
	query := `SELECT TerritoryID, TerritoryDescription, RegionID FROM Territories WHERE TerritoryID = @p1`
	row := r.db.QueryRowContext(ctx, query, id)
	var territory entities.Territory
	err := row.Scan(&territory.TerritoryID, &territory.TerritoryDescription, &territory.RegionID)
	if err != nil {
		if errors.Is(err, sql.ErrNoRows) {
			return nil, nil
		}
		return nil, err
	}
	return &territory, nil
}

func (r *TerritoryRepository) Update(ctx context.Context, territory *entities.Territory) error {
	query := `UPDATE Territories SET TerritoryDescription = @p1, RegionID = @p2 WHERE TerritoryID = @p3`
	_, err := r.db.ExecContext(ctx, query, territory.TerritoryDescription, territory.RegionID, territory.TerritoryID)
	return err
}

func (r *TerritoryRepository) Delete(ctx context.Context, id string) error {
	query := `DELETE FROM Territories WHERE TerritoryID = @p1`
	_, err := r.db.ExecContext(ctx, query, id)
	return err
}

func (r *TerritoryRepository) GetAll(ctx context.Context) ([]*entities.Territory, error) {
	query := `SELECT TerritoryID, TerritoryDescription, RegionID FROM Territories`
	rows, err := r.db.QueryContext(ctx, query)
	if err != nil {
		return nil, err
	}
	defer rows.Close()

	var territories []*entities.Territory
	for rows.Next() {
		var territory entities.Territory
		if err := rows.Scan(&territory.TerritoryID, &territory.TerritoryDescription, &territory.RegionID); err != nil {
			return nil, err
		}
		territories = append(territories, &territory)
	}
	return territories, nil
}
