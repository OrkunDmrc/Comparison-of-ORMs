package repositories

import (
	"SQLBOILER_ORM/dal/entities"
	"context"
	"database/sql"
	"errors"
)

type OrderRepository struct {
	db *sql.DB
}

func NewOrderRepository(db *sql.DB) *OrderRepository {
	return &OrderRepository{db: db}
}

func (r *OrderRepository) Create(ctx context.Context, order *entities.Order) (*entities.Order, error) {
	query := `INSERT INTO Orders (CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry) 
              VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13)`
	result, execErr := r.db.ExecContext(ctx, query, order.CustomerID, order.EmployeeID, order.OrderDate, order.RequiredDate,
		order.ShippedDate, order.ShipVia, order.Freight, order.ShipName, order.ShipAddress, order.ShipCity, order.ShipRegion,
		order.ShipPostalCode, order.ShipCountry)
	if execErr != nil {
		return nil, execErr
	}
	lastInsertID, _ := result.LastInsertId()
	order.OrderID = int(lastInsertID)
	return order, nil
}

func (r *OrderRepository) GetByID(ctx context.Context, id int) (*entities.Order, error) {
	query := `SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry 
              FROM Orders WHERE OrderID = @p1`
	row := r.db.QueryRowContext(ctx, query, id)
	var order entities.Order
	err := row.Scan(&order.OrderID, &order.CustomerID, &order.EmployeeID, &order.OrderDate, &order.RequiredDate, &order.ShippedDate,
		&order.ShipVia, &order.Freight, &order.ShipName, &order.ShipAddress, &order.ShipCity, &order.ShipRegion, &order.ShipPostalCode, &order.ShipCountry)
	if err != nil {
		if errors.Is(err, sql.ErrNoRows) {
			return nil, nil
		}
		return nil, err
	}
	return &order, nil
}

func (r *OrderRepository) Update(ctx context.Context, order *entities.Order) error {
	query := `UPDATE Orders SET CustomerID = @p1, EmployeeID = @p2, OrderDate = @p3, RequiredDate = @p4, ShippedDate = @p5, 
              ShipVia = @p6, Freight = @p7, ShipName = @p8, ShipAddress = @p9, ShipCity = @p10, ShipRegion = @p11, 
              ShipPostalCode = @p12, ShipCountry = @p13 WHERE OrderID = @p14`
	_, err := r.db.ExecContext(ctx, query, order.CustomerID, order.EmployeeID, order.OrderDate, order.RequiredDate, order.ShippedDate,
		order.ShipVia, order.Freight, order.ShipName, order.ShipAddress, order.ShipCity, order.ShipRegion, order.ShipPostalCode,
		order.ShipCountry, order.OrderID)
	return err
}

func (r *OrderRepository) Delete(ctx context.Context, id int) error {
	query := `DELETE FROM Orders WHERE OrderID = @p1`
	_, err := r.db.ExecContext(ctx, query, id)
	return err
}

func (r *OrderRepository) GetAll(ctx context.Context) ([]*entities.Order, error) {
	query := `SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry 
              FROM Orders`
	rows, err := r.db.QueryContext(ctx, query)
	if err != nil {
		return nil, err
	}
	defer rows.Close()

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
