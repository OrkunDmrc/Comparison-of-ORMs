package repositories

import (
	"SQLBOILER_ORM/dal/entities"
	"context"
	"database/sql"
	"errors"
)

type CustomerRepository struct {
	db *sql.DB
}

func NewCustomerRepository(db *sql.DB) *CustomerRepository {
	return &CustomerRepository{db: db}
}

func (r *CustomerRepository) Create(ctx context.Context, customer *entities.Customer) (*entities.Customer, error) {
	query := `INSERT INTO Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) 
              VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11)`
	_, execErr := r.db.ExecContext(ctx, query, customer.CustomerID, customer.CompanyName, customer.ContactName, customer.ContactTitle,
		customer.Address, customer.City, customer.Region, customer.PostalCode, customer.Country, customer.Phone, customer.Fax)
	if execErr != nil {
		return nil, execErr
	}
	return customer, nil
}

func (r *CustomerRepository) GetByID(ctx context.Context, id string) (*entities.Customer, error) {
	query := `SELECT * FROM Customers WHERE CustomerID = @p1`
	row := r.db.QueryRowContext(ctx, query, id)
	var customer entities.Customer
	err := row.Scan(&customer.CustomerID, &customer.CompanyName, &customer.ContactName, &customer.ContactTitle,
		&customer.Address, &customer.City, &customer.Region, &customer.PostalCode, &customer.Country, &customer.Phone, &customer.Fax)
	if err != nil {
		if errors.Is(err, sql.ErrNoRows) {
			return nil, nil
		}
		return nil, err
	}
	return &customer, nil
}

func (r *CustomerRepository) Update(ctx context.Context, customer *entities.Customer) error {
	query := `UPDATE Customers SET CompanyName = @p1, ContactName = @p2, ContactTitle = @p3, Address = @p4, City = @p5, 
              Region = @p6, PostalCode = @p7, Country = @p8, Phone = @p9, Fax = @p10 WHERE CustomerID = @p11`
	_, err := r.db.ExecContext(ctx, query, customer.CompanyName, customer.ContactName, customer.ContactTitle, customer.Address,
		customer.City, customer.Region, customer.PostalCode, customer.Country, customer.Phone, customer.Fax, customer.CustomerID)
	return err
}

func (r *CustomerRepository) Delete(ctx context.Context, id string) error {
	query := `DELETE FROM Customers WHERE CustomerID = @p1`
	_, err := r.db.ExecContext(ctx, query, id)
	return err
}

func (r *CustomerRepository) GetAll(ctx context.Context) ([]*entities.Customer, error) {
	query := `SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax 
              FROM Customers`
	rows, err := r.db.QueryContext(ctx, query)
	if err != nil {
		return nil, err
	}
	defer rows.Close()

	var customers []*entities.Customer
	for rows.Next() {
		var customer entities.Customer
		if err := rows.Scan(&customer.CustomerID, &customer.CompanyName, &customer.ContactName, &customer.ContactTitle,
			&customer.Address, &customer.City, &customer.Region, &customer.PostalCode, &customer.Country, &customer.Phone, &customer.Fax); err != nil {
			return nil, err
		}
		customers = append(customers, &customer)
	}
	return customers, nil
}
