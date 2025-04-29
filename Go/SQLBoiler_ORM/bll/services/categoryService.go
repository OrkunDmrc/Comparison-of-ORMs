package services

import (
	"SQLBOILER_ORM/dal/entities"
	"SQLBOILER_ORM/dal/repositories"
	"context"
)

type CategoryService struct {
	repo *repositories.CategoryRepository
}

func NewCategoryService(repo *repositories.CategoryRepository) *CategoryService {
	return &CategoryService{repo: repo}
}

func (s *CategoryService) GetByID(ctx context.Context, id int) (*entities.Category, error) {
	category, err := s.repo.GetByID(ctx, id)
	if err != nil {
		return nil, err
	}
	return category, nil
}

func (s *CategoryService) GetAll(ctx context.Context) ([]*entities.Category, error) {
	return s.repo.GetAll(ctx)
}

func (s *CategoryService) Create(ctx context.Context, category *entities.Category) (*entities.Category, error) {
	return s.repo.Create(ctx, category)
}

func (s *CategoryService) Update(ctx context.Context, category *entities.Category) error {
	return s.repo.Update(ctx, category)
}

func (s *CategoryService) Delete(ctx context.Context, id int) error {
	return s.repo.Delete(ctx, id)
}
