package services

import (
	"GORM_ORM/dal/entities"
	"GORM_ORM/dal/repositories"
)

type CustomerService interface {
	GetAll() ([]entities.Customer, error)
	GetByID(id string) (*entities.Customer, error)
	Create(customer *entities.Customer) error
	Update(customer *entities.Customer) error
	Delete(id string) error
}

type customerService struct {
	repo repositories.CustomerRepository
}

func NewCustomerService(repo repositories.CustomerRepository) CustomerService {
	return &customerService{repo: repo}
}

func (s *customerService) GetAll() ([]entities.Customer, error) {
	return s.repo.GetAll()
}

func (s *customerService) GetByID(id string) (*entities.Customer, error) {
	return s.repo.GetByID(id)
}

func (s *customerService) Create(customer *entities.Customer) error {
	return s.repo.Create(customer)
}

func (s *customerService) Update(customer *entities.Customer) error {
	return s.repo.Update(customer)
}

func (s *customerService) Delete(id string) error {
	return s.repo.Delete(id)
}
