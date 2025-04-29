package repositories

import (
	"SQLBOILER_ORM/dal/entities"
	"context"
	"database/sql"
	"errors"
)

type CategoryRepository struct {
	db *sql.DB
}

func NewCategoryRepository(db *sql.DB) *CategoryRepository {
	return &CategoryRepository{db: db}
}

func (r *CategoryRepository) Create(ctx context.Context, category *entities.Category) (*entities.Category, error) {
	query := `INSERT INTO Categories (CategoryName, Description, Picture) VALUES (@p1, @p2, @p3)`
	entity, execErr := r.db.ExecContext(ctx, query, category.CategoryName, category.Description, category.Picture)
	if execErr != nil {
		return nil, execErr
	}
	lastInsertID, _ := entity.LastInsertId()
	category.CategoryID = int(lastInsertID)
	return category, nil
}

func (r *CategoryRepository) GetByID(ctx context.Context, id int) (*entities.Category, error) {
	query := `SELECT CategoryID, CategoryName, Description, Picture FROM Categories WHERE CategoryID = @p1`
	row := r.db.QueryRowContext(ctx, query, id)
	var category entities.Category
	err := row.Scan(&category.CategoryID, &category.CategoryName, &category.Description, &category.Picture)
	if err != nil {
		if errors.Is(err, sql.ErrNoRows) {
			return nil, nil
		}
		return nil, err
	}
	return &category, nil
}

func (r *CategoryRepository) Update(ctx context.Context, category *entities.Category) error {
	query := `UPDATE Categories SET CategoryName = @p1, Description = @p2, Picture = @p3 WHERE CategoryID = @p4`
	_, err := r.db.ExecContext(ctx, query, category.CategoryName, category.Description, category.Picture, category.CategoryID)
	return err
}

func (r *CategoryRepository) Delete(ctx context.Context, id int) error {
	query := `DELETE FROM Categories WHERE CategoryID = @p1`
	_, err := r.db.ExecContext(ctx, query, id)
	return err
}

func (r *CategoryRepository) GetAll(ctx context.Context) ([]*entities.Category, error) {
	query := `SELECT CategoryID, CategoryName, Description, Picture FROM Categories`
	rows, err := r.db.QueryContext(ctx, query)
	if err != nil {
		return nil, err
	}
	defer rows.Close()

	var categories []*entities.Category
	for rows.Next() {
		var category entities.Category
		if err := rows.Scan(&category.CategoryID, &category.CategoryName, &category.Description, &category.Picture); err != nil {
			return nil, err
		}
		categories = append(categories, &category)
	}
	return categories, nil
}
