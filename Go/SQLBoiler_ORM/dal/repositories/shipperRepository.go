package repositories

import (
	"SQLBOILER_ORM/dal/entities"
	"context"
	"database/sql"
	"errors"
)

type ShipperRepository struct {
	db *sql.DB
}

func NewShipperRepository(db *sql.DB) *ShipperRepository {
	return &ShipperRepository{db: db}
}

func (r *ShipperRepository) Create(ctx context.Context, shipper *entities.Shipper) (*entities.Shipper, error) {
	query := `INSERT INTO Shippers (CompanyName, Phone) VALUES (@p1, @p2)`
	result, execErr := r.db.ExecContext(ctx, query, shipper.CompanyName, shipper.Phone)
	if execErr != nil {
		return nil, execErr
	}
	lastInsertID, _ := result.LastInsertId()
	shipper.ShipperID = int(lastInsertID)
	return shipper, nil
}

func (r *ShipperRepository) GetByID(ctx context.Context, id int) (*entities.Shipper, error) {
	query := `SELECT * FROM Shippers WHERE ShipperID = @p1`
	row := r.db.QueryRowContext(ctx, query, id)
	var shipper entities.Shipper
	err := row.Scan(&shipper.ShipperID, &shipper.CompanyName, &shipper.Phone)
	if err != nil {
		if errors.Is(err, sql.ErrNoRows) {
			return nil, nil
		}
		return nil, err
	}
	return &shipper, nil
}

func (r *ShipperRepository) Update(ctx context.Context, shipper *entities.Shipper) error {
	query := `UPDATE Shippers SET CompanyName = @p1, Phone = @p2 WHERE ShipperID = @p3`
	_, err := r.db.ExecContext(ctx, query, shipper.CompanyName, shipper.Phone, shipper.ShipperID)
	return err
}

func (r *ShipperRepository) Delete(ctx context.Context, id int) error {
	query := `DELETE FROM Shippers WHERE ShipperID = @p1`
	_, err := r.db.ExecContext(ctx, query, id)
	return err
}

func (r *ShipperRepository) GetAll(ctx context.Context) ([]*entities.Shipper, error) {
	query := `SELECT * FROM Shippers`
	rows, err := r.db.QueryContext(ctx, query)
	if err != nil {
		return nil, err
	}
	defer rows.Close()

	var shippers []*entities.Shipper
	for rows.Next() {
		var shipper entities.Shipper
		if err := rows.Scan(&shipper.ShipperID, &shipper.CompanyName, &shipper.Phone); err != nil {
			return nil, err
		}
		shippers = append(shippers, &shipper)
	}
	return shippers, nil
}
