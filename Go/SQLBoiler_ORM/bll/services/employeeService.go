package services

import (
	"SQLBOILER_ORM/dal/entities"
	"SQLBOILER_ORM/dal/repositories"
	"context"
)

type EmployeeService struct {
	repo *repositories.EmployeeRepository
}

func NewEmployeeService(repo *repositories.EmployeeRepository) *EmployeeService {
	return &EmployeeService{repo: repo}
}

func (s *EmployeeService) GetByID(ctx context.Context, id int) (*entities.Employee, error) {
	employee, err := s.repo.GetByID(ctx, id)
	if err != nil {
		return nil, err
	}
	return employee, nil
}

func (s *EmployeeService) GetAll(ctx context.Context) ([]*entities.Employee, error) {
	return s.repo.GetAll(ctx)
}

func (s *EmployeeService) Create(ctx context.Context, employee *entities.Employee) (*entities.Employee, error) {
	return s.repo.Create(ctx, employee)
}

func (s *EmployeeService) Update(ctx context.Context, employee *entities.Employee) error {
	return s.repo.Update(ctx, employee)
}

func (s *EmployeeService) Delete(ctx context.Context, id int) error {
	return s.repo.Delete(ctx, id)
}
