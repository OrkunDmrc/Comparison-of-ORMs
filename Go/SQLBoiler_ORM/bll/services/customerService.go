package services

import (
	"SQLBOILER_ORM/dal/entities"
	"SQLBOILER_ORM/dal/repositories"
	"context"
)

type CustomerService struct {
	repo *repositories.CustomerRepository
}

func NewCustomerService(repo *repositories.CustomerRepository) *CustomerService {
	return &CustomerService{repo: repo}
}

func (s *CustomerService) GetByID(ctx context.Context, id string) (*entities.Customer, error) {
	customer, err := s.repo.GetByID(ctx, id)
	if err != nil {
		return nil, err
	}
	return customer, nil
}

func (s *CustomerService) GetAll(ctx context.Context) ([]*entities.Customer, error) {
	return s.repo.GetAll(ctx)
}

func (s *CustomerService) Create(ctx context.Context, customer *entities.Customer) (*entities.Customer, error) {
	return s.repo.Create(ctx, customer)
}

func (s *CustomerService) Update(ctx context.Context, customer *entities.Customer) error {
	return s.repo.Update(ctx, customer)
}

func (s *CustomerService) Delete(ctx context.Context, id string) error {
	return s.repo.Delete(ctx, id)
}
