package services

import (
	"SQLBOILER_ORM/dal/entities"
	"SQLBOILER_ORM/dal/repositories"
	"context"
)

type ProductService struct {
	repo *repositories.ProductRepository
}

func NewProductService(repo *repositories.ProductRepository) *ProductService {
	return &ProductService{repo: repo}
}

func (s *ProductService) GetByID(ctx context.Context, id int) (*entities.Product, error) {
	product, err := s.repo.GetByID(ctx, id)
	if err != nil {
		return nil, err
	}
	return product, nil
}

func (s *ProductService) GetAll(ctx context.Context) ([]*entities.Product, error) {
	return s.repo.GetAll(ctx)
}

func (s *ProductService) Create(ctx context.Context, product *entities.Product) (*entities.Product, error) {
	return s.repo.Create(ctx, product)
}

func (s *ProductService) Update(ctx context.Context, product *entities.Product) error {
	return s.repo.Update(ctx, product)
}

func (s *ProductService) Delete(ctx context.Context, id int) error {
	return s.repo.Delete(ctx, id)
}
