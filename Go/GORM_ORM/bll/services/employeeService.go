package services

import (
	"GORM_ORM/dal/entities"
	"GORM_ORM/dal/repositories"
)

type EmployeeService interface {
	GetAll() ([]entities.Employee, error)
	GetByID(id int) (*entities.Employee, error)
	Create(employee *entities.Employee) error
	Update(employee *entities.Employee) error
	Delete(id int) error
}

type employeeService struct {
	repo repositories.EmployeeRepository
}

func NewEmployeeService(repo repositories.EmployeeRepository) EmployeeService {
	return &employeeService{repo: repo}
}

func (s *employeeService) GetAll() ([]entities.Employee, error) {
	return s.repo.GetAll()
}

func (s *employeeService) GetByID(id int) (*entities.Employee, error) {
	return s.repo.GetByID(id)
}

func (s *employeeService) Create(employee *entities.Employee) error {
	return s.repo.Create(employee)
}

func (s *employeeService) Update(employee *entities.Employee) error {
	return s.repo.Update(employee)
}

func (s *employeeService) Delete(id int) error {
	return s.repo.Delete(id)
}
