package services

import (
	"GORM_ORM/dal/entities"
	"GORM_ORM/dal/repositories"
)

type OrderService interface {
	GetAll() ([]entities.Order, error)
	GetByID(id int) (*entities.Order, error)
	Create(order *entities.Order) (*entities.Order, error)
	Update(order *entities.Order) error
	Delete(id int) error
}

type orderService struct {
	repo repositories.OrderRepository
}

func NewOrderService(repo repositories.OrderRepository) OrderService {
	return &orderService{repo: repo}
}

func (s *orderService) GetAll() ([]entities.Order, error) {
	return s.repo.GetAll()
}

func (s *orderService) GetByID(id int) (*entities.Order, error) {
	return s.repo.GetByID(id)
}

func (s *orderService) Create(order *entities.Order) (*entities.Order, error) {
	return s.repo.Create(order)
}

func (s *orderService) Update(order *entities.Order) error {
	return s.repo.Update(order)
}

func (s *orderService) Delete(id int) error {
	return s.repo.Delete(id)
}
