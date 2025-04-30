package services

import (
	"SQLBOILER_ORM/dal/entities"
	"SQLBOILER_ORM/dal/repositories"
	"context"
)

type OrderService struct {
	repo *repositories.OrderRepository
}

func NewOrderService(repo *repositories.OrderRepository) *OrderService {
	return &OrderService{repo: repo}
}

func (s *OrderService) GetByID(ctx context.Context, id int) (*entities.Order, error) {
	return s.repo.GetByID(ctx, id)
}

func (s *OrderService) GetAll(ctx context.Context) ([]*entities.Order, error) {
	return s.repo.GetAll(ctx)
}

func (s *OrderService) Create(ctx context.Context, order *entities.Order) (*entities.Order, error) {
	return s.repo.Create(ctx, order)
}

func (s *OrderService) Update(ctx context.Context, order *entities.Order) error {
	return s.repo.Update(ctx, order)
}

func (s *OrderService) Delete(ctx context.Context, id int) error {
	return s.repo.Delete(ctx, id)
}
