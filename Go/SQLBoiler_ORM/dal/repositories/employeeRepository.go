package repositories

import (
	"SQLBOILER_ORM/dal/entities"
	"context"
	"database/sql"
	"errors"
)

type EmployeeRepository struct {
	db *sql.DB
}

func NewEmployeeRepository(db *sql.DB) *EmployeeRepository {
	return &EmployeeRepository{db: db}
}

func (r *EmployeeRepository) Create(ctx context.Context, employee *entities.Employee) (*entities.Employee, error) {
	query := `INSERT INTO Employees (LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath) 
              VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16, @p17)`
	result, execErr := r.db.ExecContext(ctx, query, employee.LastName, employee.FirstName, employee.Title, employee.TitleOfCourtesy,
		employee.BirthDate, employee.HireDate, employee.Address, employee.City, employee.Region, employee.PostalCode, employee.Country,
		employee.HomePhone, employee.Extension, employee.Photo, employee.Notes, employee.ReportsTo, employee.PhotoPath)
	if execErr != nil {
		return nil, execErr
	}
	lastInsertID, _ := result.LastInsertId()
	employee.EmployeeID = int(lastInsertID)
	return employee, nil
}

func (r *EmployeeRepository) GetByID(ctx context.Context, id int) (*entities.Employee, error) {
	query := `SELECT * FROM Employees WHERE EmployeeID = @p1`
	row := r.db.QueryRowContext(ctx, query, id)
	var employee entities.Employee
	err := row.Scan(&employee.EmployeeID, &employee.LastName, &employee.FirstName, &employee.Title, &employee.TitleOfCourtesy,
		&employee.BirthDate, &employee.HireDate, &employee.Address, &employee.City, &employee.Region, &employee.PostalCode,
		&employee.Country, &employee.HomePhone, &employee.Extension, &employee.Photo, &employee.Notes, &employee.ReportsTo, &employee.PhotoPath)
	if err != nil {
		if errors.Is(err, sql.ErrNoRows) {
			return nil, nil
		}
		return nil, err
	}
	return &employee, nil
}

func (r *EmployeeRepository) Update(ctx context.Context, employee *entities.Employee) error {
	query := `UPDATE Employees SET LastName = @p1, FirstName = @p2, Title = @p3, TitleOfCourtesy = @p4, BirthDate = @p5, HireDate = @p6, 
              Address = @p7, City = @p8, Region = @p9, PostalCode = @p10, Country = @p11, HomePhone = @p12, Extension = @p13, 
              Photo = @p14, Notes = @p15, ReportsTo = @p16, PhotoPath = @p17 WHERE EmployeeID = @p18`
	_, err := r.db.ExecContext(ctx, query, employee.LastName, employee.FirstName, employee.Title, employee.TitleOfCourtesy,
		employee.BirthDate, employee.HireDate, employee.Address, employee.City, employee.Region, employee.PostalCode, employee.Country,
		employee.HomePhone, employee.Extension, employee.Photo, employee.Notes, employee.ReportsTo, employee.PhotoPath, employee.EmployeeID)
	return err
}

func (r *EmployeeRepository) Delete(ctx context.Context, id int) error {
	query := `DELETE FROM Employees WHERE EmployeeID = @p1`
	_, err := r.db.ExecContext(ctx, query, id)
	return err
}

func (r *EmployeeRepository) GetAll(ctx context.Context) ([]*entities.Employee, error) {
	query := `SELECT * FROM Employees`
	rows, err := r.db.QueryContext(ctx, query)
	if err != nil {
		return nil, err
	}
	defer rows.Close()

	var employees []*entities.Employee
	for rows.Next() {
		var employee entities.Employee
		if err := rows.Scan(&employee.EmployeeID, &employee.LastName, &employee.FirstName, &employee.Title, &employee.TitleOfCourtesy,
			&employee.BirthDate, &employee.HireDate, &employee.Address, &employee.City, &employee.Region, &employee.PostalCode,
			&employee.Country, &employee.HomePhone, &employee.Extension, &employee.Photo, &employee.Notes, &employee.ReportsTo, &employee.PhotoPath); err != nil {
			return nil, err
		}
		employees = append(employees, &employee)
	}
	return employees, nil
}
