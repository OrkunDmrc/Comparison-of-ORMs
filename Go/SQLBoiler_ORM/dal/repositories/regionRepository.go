package repositories

import (
	"SQLBOILER_ORM/dal/entities"
	"context"
	"database/sql"
	"errors"
)

type RegionRepository struct {
	db *sql.DB
}

func NewRegionRepository(db *sql.DB) *RegionRepository {
	return &RegionRepository{db: db}
}

func (r *RegionRepository) Create(ctx context.Context, region *entities.Region) (*entities.Region, error) {
	query := `INSERT INTO Region (RegionID, RegionDescription) VALUES (@p1, @p2)`
	_, execErr := r.db.ExecContext(ctx, query, region.RegionID, region.RegionDescription)
	if execErr != nil {
		return nil, execErr
	}
	return region, nil
}

func (r *RegionRepository) GetByID(ctx context.Context, id int) (*entities.Region, error) {
	query := `SELECT * FROM Region WHERE RegionID = @p1`
	row := r.db.QueryRowContext(ctx, query, id)
	var region entities.Region
	err := row.Scan(&region.RegionID, &region.RegionDescription)
	if err != nil {
		if errors.Is(err, sql.ErrNoRows) {
			return nil, nil
		}
		return nil, err
	}
	return &region, nil
}

func (r *RegionRepository) Update(ctx context.Context, region *entities.Region) error {
	query := `UPDATE Region SET RegionDescription = @p1 WHERE RegionID = @p2`
	_, err := r.db.ExecContext(ctx, query, region.RegionDescription, region.RegionID)
	return err
}

func (r *RegionRepository) Delete(ctx context.Context, id int) error {
	query := `DELETE FROM Region WHERE RegionID = @p1`
	_, err := r.db.ExecContext(ctx, query, id)
	return err
}

func (r *RegionRepository) GetAll(ctx context.Context) ([]*entities.Region, error) {
	query := `SELECT * FROM Region`
	rows, err := r.db.QueryContext(ctx, query)
	if err != nil {
		return nil, err
	}
	defer rows.Close()

	var regions []*entities.Region
	for rows.Next() {
		var region entities.Region
		if err := rows.Scan(&region.RegionID, &region.RegionDescription); err != nil {
			return nil, err
		}
		regions = append(regions, &region)
	}
	return regions, nil
}
