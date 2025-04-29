package repositories

import (
	"SQLBOILER_ORM/dal/entities"
	"context"
	"database/sql"
	"errors"
)

type OrderDetailRepository struct {
	db *sql.DB
}

func NewOrderDetailRepository(db *sql.DB) *OrderDetailRepository {
	return &OrderDetailRepository{db: db}
}

func (r *OrderDetailRepository) Create(ctx context.Context, orderDetail *entities.OrderDetail) (*entities.OrderDetail, error) {
	query := `INSERT INTO [Order Details] (OrderID, ProductID, UnitPrice, Quantity, Discount) VALUES (@p1, @p2, @p3, @p4, @p5)`
	_, execErr := r.db.ExecContext(ctx, query, orderDetail.OrderID, orderDetail.ProductID, orderDetail.UnitPrice, orderDetail.Quantity, orderDetail.Discount)
	if execErr != nil {
		return nil, execErr
	}
	return orderDetail, nil
}

func (r *OrderDetailRepository) GetByOrderIDAndProductID(ctx context.Context, orderID int, productID int) (*entities.OrderDetail, error) {
	query := `SELECT OrderID, ProductID, UnitPrice, Quantity, Discount FROM [Order Details] WHERE OrderID = @p1 AND ProductID = @p2`
	row := r.db.QueryRowContext(ctx, query, orderID, productID)
	var orderDetail entities.OrderDetail
	err := row.Scan(&orderDetail.OrderID, &orderDetail.ProductID, &orderDetail.UnitPrice, &orderDetail.Quantity, &orderDetail.Discount)
	if err != nil {
		if errors.Is(err, sql.ErrNoRows) {
			return nil, nil
		}
		return nil, err
	}
	return &orderDetail, nil
}

func (r *OrderDetailRepository) Update(ctx context.Context, orderDetail *entities.OrderDetail) error {
	query := `UPDATE [Order Details] SET UnitPrice = @p1, Quantity = @p2, Discount = @p3 WHERE OrderID = @p4 AND ProductID = @p5`
	_, err := r.db.ExecContext(ctx, query, orderDetail.UnitPrice, orderDetail.Quantity, orderDetail.Discount, orderDetail.OrderID, orderDetail.ProductID)
	return err
}

func (r *OrderDetailRepository) Delete(ctx context.Context, orderID int, productID int) error {
	query := `DELETE FROM [Order Details] WHERE OrderID = @p1 AND ProductID = @p2`
	_, err := r.db.ExecContext(ctx, query, orderID, productID)
	return err
}

func (r *OrderDetailRepository) GetAll(ctx context.Context) ([]*entities.OrderDetail, error) {
	query := `SELECT OrderID, ProductID, UnitPrice, Quantity, Discount FROM [Order Details]`
	rows, err := r.db.QueryContext(ctx, query)
	if err != nil {
		return nil, err
	}
	defer rows.Close()

	var orderDetails []*entities.OrderDetail
	for rows.Next() {
		var orderDetail entities.OrderDetail
		if err := rows.Scan(&orderDetail.OrderID, &orderDetail.ProductID, &orderDetail.UnitPrice, &orderDetail.Quantity, &orderDetail.Discount); err != nil {
			return nil, err
		}
		orderDetails = append(orderDetails, &orderDetail)
	}
	return orderDetails, nil
}
