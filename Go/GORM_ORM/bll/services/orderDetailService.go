package services

import (
	"GORM_ORM/dal/entities"
	"GORM_ORM/dal/repositories"
)

type OrderDetailService interface {
	GetAll() ([]entities.OrderDetail, error)
	GetByID(orderId int, productId int) (*entities.OrderDetail, error)
	Create(orderDetail *entities.OrderDetail) error
	Delete(orderId int, productId int) error
}

type orderDetailService struct {
	repo repositories.OrderDetailRepository
}

func NewOrderDetailService(repo repositories.OrderDetailRepository) OrderDetailService {
	return &orderDetailService{repo: repo}
}

func (s *orderDetailService) GetAll() ([]entities.OrderDetail, error) {
	return s.repo.GetAll()
}

func (s *orderDetailService) GetByID(orderId int, productId int) (*entities.OrderDetail, error) {
	return s.repo.GetByID(orderId, productId)
}

func (s *orderDetailService) Create(orderDetail *entities.OrderDetail) error {
	return s.repo.Create(orderDetail)
}

func (s *orderDetailService) Delete(orderId int, productId int) error {
	return s.repo.Delete(orderId, productId)
}
