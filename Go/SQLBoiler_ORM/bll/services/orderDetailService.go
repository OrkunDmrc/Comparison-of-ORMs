package services

import (
	"SQLBOILER_ORM/dal/entities"
	"SQLBOILER_ORM/dal/repositories"
	"context"
)

type OrderDetailService struct {
	repo *repositories.OrderDetailRepository
}

func NewOrderDetailService(repo *repositories.OrderDetailRepository) *OrderDetailService {
	return &OrderDetailService{repo: repo}
}

func (s *OrderDetailService) GetByOrderIDAndProductID(ctx context.Context, orderID int, productID int) (*entities.OrderDetail, error) {
	orderDetail, err := s.repo.GetByOrderIDAndProductID(ctx, orderID, productID)
	if err != nil {
		return nil, err
	}
	return orderDetail, nil
}

func (s *OrderDetailService) GetAll(ctx context.Context) ([]*entities.OrderDetail, error) {
	return s.repo.GetAll(ctx)
}

func (s *OrderDetailService) Create(ctx context.Context, orderDetail *entities.OrderDetail) (*entities.OrderDetail, error) {
	return s.repo.Create(ctx, orderDetail)
}

func (s *OrderDetailService) Update(ctx context.Context, orderDetail *entities.OrderDetail) error {
	return s.repo.Update(ctx, orderDetail)
}

func (s *OrderDetailService) Delete(ctx context.Context, orderID int, productID int) error {
	return s.repo.Delete(ctx, orderID, productID)
}
