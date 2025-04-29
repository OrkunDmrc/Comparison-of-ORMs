package repositories

import (
	"SQLBOILER_ORM/dal/entities"
	"context"
	"database/sql"
	"errors"
)

type ProductRepository struct {
	db *sql.DB
}

func NewProductRepository(db *sql.DB) *ProductRepository {
	return &ProductRepository{db: db}
}

func (r *ProductRepository) Create(ctx context.Context, product *entities.Product) (*entities.Product, error) {
	query := `INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) 
              VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9)`
	result, execErr := r.db.ExecContext(ctx, query, product.ProductName, product.SupplierID, product.CategoryID, product.QuantityPerUnit,
		product.UnitPrice, product.UnitsInStock, product.UnitsOnOrder, product.ReorderLevel, product.Discontinued)
	if execErr != nil {
		return nil, execErr
	}
	lastInsertID, _ := result.LastInsertId()
	product.ProductID = int(lastInsertID)
	return product, nil
}

func (r *ProductRepository) GetByID(ctx context.Context, id int) (*entities.Product, error) {
	query := `SELECT * FROM Products WHERE ProductID = @p1`
	row := r.db.QueryRowContext(ctx, query, id)
	var product entities.Product
	err := row.Scan(&product.ProductID, &product.ProductName, &product.SupplierID, &product.CategoryID, &product.QuantityPerUnit,
		&product.UnitPrice, &product.UnitsInStock, &product.UnitsOnOrder, &product.ReorderLevel, &product.Discontinued)
	if err != nil {
		if errors.Is(err, sql.ErrNoRows) {
			return nil, nil
		}
		return nil, err
	}
	return &product, nil
}

func (r *ProductRepository) Update(ctx context.Context, product *entities.Product) error {
	query := `UPDATE Products SET ProductName = @p1, SupplierID = @p2, CategoryID = @p3, QuantityPerUnit = @p4, UnitPrice = @p5, 
              UnitsInStock = @p6, UnitsOnOrder = @p7, ReorderLevel = @p8, Discontinued = @p9 WHERE ProductID = @p10`
	_, err := r.db.ExecContext(ctx, query, product.ProductName, product.SupplierID, product.CategoryID, product.QuantityPerUnit,
		product.UnitPrice, product.UnitsInStock, product.UnitsOnOrder, product.ReorderLevel, product.Discontinued, product.ProductID)
	return err
}

func (r *ProductRepository) Delete(ctx context.Context, id int) error {
	query := `DELETE FROM Products WHERE ProductID = @p1`
	_, err := r.db.ExecContext(ctx, query, id)
	return err
}

func (r *ProductRepository) GetAll(ctx context.Context) ([]*entities.Product, error) {
	query := `SELECT * FROM Products`
	rows, err := r.db.QueryContext(ctx, query)
	if err != nil {
		return nil, err
	}
	defer rows.Close()

	var products []*entities.Product
	for rows.Next() {
		var product entities.Product
		if err := rows.Scan(&product.ProductID, &product.ProductName, &product.SupplierID, &product.CategoryID, &product.QuantityPerUnit,
			&product.UnitPrice, &product.UnitsInStock, &product.UnitsOnOrder, &product.ReorderLevel, &product.Discontinued); err != nil {
			return nil, err
		}
		products = append(products, &product)
	}
	return products, nil
}
