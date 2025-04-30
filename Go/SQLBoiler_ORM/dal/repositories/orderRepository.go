package repositories

import (
	"SQLBOILER_ORM/dal/entities"
	"context"
	"database/sql"
	"errors"
	"time"
)

type OrderRepository struct {
	db           *sql.DB
	testDataRepo *TestDataRepository
}

func NewOrderRepository(db *sql.DB, testDataRepo *TestDataRepository) *OrderRepository {
	return &OrderRepository{db: db, testDataRepo: testDataRepo}
}

func (r *OrderRepository) Create(ctx context.Context, order *entities.Order) (*entities.Order, error) {
	query := `INSERT INTO Orders (CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry) 
              VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13)`
	start := time.Now()
	result, execErr := r.db.ExecContext(ctx, query, order.CustomerID, order.EmployeeID, order.OrderDate, order.RequiredDate,
		order.ShippedDate, order.ShipVia, order.Freight, order.ShipName, order.ShipAddress, order.ShipCity, order.ShipRegion,
		order.ShipPostalCode, order.ShipCountry)
	duration := time.Since(start)
	if execErr != nil {
		return nil, execErr
	}
	lastInsertID, _ := result.LastInsertId()
	order.OrderID = int(lastInsertID)
	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("SQLBoiler Create Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr( /*formatMemory(memoryUsageMB)*/ "0 MB"),
		CpuUsage:    stringPtr("0 ms"),
	}
	_, err := r.testDataRepo.Create(ctx, testData)
	if err != nil {
		return nil, err
	}
	return order, nil
}

func (r *OrderRepository) GetByID(ctx context.Context, id int) (*entities.Order, error) {
	query := `SELECT * FROM Orders WHERE OrderID = @p1`
	start := time.Now()
	row := r.db.QueryRowContext(ctx, query, id)
	duration := time.Since(start)
	var order entities.Order
	err := row.Scan(&order.OrderID, &order.CustomerID, &order.EmployeeID, &order.OrderDate, &order.RequiredDate, &order.ShippedDate,
		&order.ShipVia, &order.Freight, &order.ShipName, &order.ShipAddress, &order.ShipCity, &order.ShipRegion, &order.ShipPostalCode, &order.ShipCountry)
	if err != nil {
		if errors.Is(err, sql.ErrNoRows) {
			return nil, nil
		}
		return nil, err
	}
	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("SQLBoiler Get Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr( /*formatMemory(memoryUsageMB)*/ "0 MB"),
		CpuUsage:    stringPtr("0 ms"),
	}
	_, err = r.testDataRepo.Create(ctx, testData)
	if err != nil {
		return nil, err
	}
	return &order, nil
}

func (r *OrderRepository) Update(ctx context.Context, order *entities.Order) error {
	query := `UPDATE Orders SET CustomerID = @p1, EmployeeID = @p2, OrderDate = @p3, RequiredDate = @p4, ShippedDate = @p5, 
              ShipVia = @p6, Freight = @p7, ShipName = @p8, ShipAddress = @p9, ShipCity = @p10, ShipRegion = @p11, 
              ShipPostalCode = @p12, ShipCountry = @p13 WHERE OrderID = @p14`
	start := time.Now()
	_, err := r.db.ExecContext(ctx, query, order.CustomerID, order.EmployeeID, order.OrderDate, order.RequiredDate, order.ShippedDate,
		order.ShipVia, order.Freight, order.ShipName, order.ShipAddress, order.ShipCity, order.ShipRegion, order.ShipPostalCode,
		order.ShipCountry, order.OrderID)
	duration := time.Since(start)
	if err != nil {
		return err
	}
	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("SQLBoiler Update Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr( /*formatMemory(memoryUsageMB)*/ "0 MB"),
		CpuUsage:    stringPtr("0 ms"),
	}
	_, err = r.testDataRepo.Create(ctx, testData)
	if err != nil {
		return err
	}
	return err
}

func (r *OrderRepository) Delete(ctx context.Context, id int) error {
	query := `DELETE FROM Orders WHERE OrderID = @p1`
	start := time.Now()
	_, err := r.db.ExecContext(ctx, query, id)
	duration := time.Since(start)
	if err != nil {
		return err
	}
	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("SQLBoiler Delete Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr( /*formatMemory(memoryUsageMB)*/ "0 MB"),
		CpuUsage:    stringPtr("0 ms"),
	}
	_, err = r.testDataRepo.Create(ctx, testData)
	if err != nil {
		return err
	}
	return err
}

func (r *OrderRepository) GetAll(ctx context.Context) ([]*entities.Order, error) {
	query := `SELECT * FROM Orders`
	start := time.Now()
	rows, err := r.db.QueryContext(ctx, query)
	duration := time.Since(start)
	if err != nil {
		return nil, err
	}
	defer rows.Close()
	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("SQLBoiler Get All Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr( /*formatMemory(memoryUsageMB)*/ "0 MB"),
		CpuUsage:    stringPtr("0 ms"),
	}
	_, err = r.testDataRepo.Create(ctx, testData)
	if err != nil {
		return nil, err
	}
	var orders []*entities.Order
	for rows.Next() {
		var order entities.Order
		if err := rows.Scan(&order.OrderID, &order.CustomerID, &order.EmployeeID, &order.OrderDate, &order.RequiredDate, &order.ShippedDate,
			&order.ShipVia, &order.Freight, &order.ShipName, &order.ShipAddress, &order.ShipCity, &order.ShipRegion, &order.ShipPostalCode, &order.ShipCountry); err != nil {
			return nil, err
		}
		orders = append(orders, &order)
	}
	return orders, nil
}

func stringPtr(s string) *string {
	return &s
}
