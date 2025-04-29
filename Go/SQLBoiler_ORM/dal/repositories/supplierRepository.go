package repositories

import (
	"SQLBOILER_ORM/dal/entities"
	"context"
	"database/sql"
	"errors"
)

type SupplierRepository struct {
	db *sql.DB
}

func NewSupplierRepository(db *sql.DB) *SupplierRepository {
	return &SupplierRepository{db: db}
}

func (r *SupplierRepository) Create(ctx context.Context, supplier *entities.Supplier) (*entities.Supplier, error) {
	query := `INSERT INTO Suppliers (CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage) 
              VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11)`
	result, execErr := r.db.ExecContext(ctx, query, supplier.CompanyName, supplier.ContactName, supplier.ContactTitle, supplier.Address,
		supplier.City, supplier.Region, supplier.PostalCode, supplier.Country, supplier.Phone, supplier.Fax, supplier.HomePage)
	if execErr != nil {
		return nil, execErr
	}
	lastInsertID, _ := result.LastInsertId()
	supplier.SupplierID = int(lastInsertID)
	return supplier, nil
}

func (r *SupplierRepository) GetByID(ctx context.Context, id int) (*entities.Supplier, error) {
	query := `SELECT SupplierID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage 
              FROM Suppliers WHERE SupplierID = @p1`
	row := r.db.QueryRowContext(ctx, query, id)
	var supplier entities.Supplier
	err := row.Scan(&supplier.SupplierID, &supplier.CompanyName, &supplier.ContactName, &supplier.ContactTitle, &supplier.Address,
		&supplier.City, &supplier.Region, &supplier.PostalCode, &supplier.Country, &supplier.Phone, &supplier.Fax, &supplier.HomePage)
	if err != nil {
		if errors.Is(err, sql.ErrNoRows) {
			return nil, nil
		}
		return nil, err
	}
	return &supplier, nil
}

func (r *SupplierRepository) Update(ctx context.Context, supplier *entities.Supplier) error {
	query := `UPDATE Suppliers SET CompanyName = @p1, ContactName = @p2, ContactTitle = @p3, Address = @p4, City = @p5, Region = @p6, 
              PostalCode = @p7, Country = @p8, Phone = @p9, Fax = @p10, HomePage = @p11 WHERE SupplierID = @p12`
	_, err := r.db.ExecContext(ctx, query, supplier.CompanyName, supplier.ContactName, supplier.ContactTitle, supplier.Address,
		supplier.City, supplier.Region, supplier.PostalCode, supplier.Country, supplier.Phone, supplier.Fax, supplier.HomePage, supplier.SupplierID)
	return err
}

func (r *SupplierRepository) Delete(ctx context.Context, id int) error {
	query := `DELETE FROM Suppliers WHERE SupplierID = @p1`
	_, err := r.db.ExecContext(ctx, query, id)
	return err
}

func (r *SupplierRepository) GetAll(ctx context.Context) ([]*entities.Supplier, error) {
	query := `SELECT SupplierID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage 
              FROM Suppliers`
	rows, err := r.db.QueryContext(ctx, query)
	if err != nil {
		return nil, err
	}
	defer rows.Close()

	var suppliers []*entities.Supplier
	for rows.Next() {
		var supplier entities.Supplier
		if err := rows.Scan(&supplier.SupplierID, &supplier.CompanyName, &supplier.ContactName, &supplier.ContactTitle, &supplier.Address,
			&supplier.City, &supplier.Region, &supplier.PostalCode, &supplier.Country, &supplier.Phone, &supplier.Fax, &supplier.HomePage); err != nil {
			return nil, err
		}
		suppliers = append(suppliers, &supplier)
	}
	return suppliers, nil
}
