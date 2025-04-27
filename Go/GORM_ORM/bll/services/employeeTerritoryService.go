package services

import (
	"GORM_ORM/dal/entities"
	"GORM_ORM/dal/repositories"
)

type EmployeeTerritoryService interface {
	GetAll() ([]entities.EmployeeTerritory, error)
	GetByID(id int) (*entities.EmployeeTerritory, error)
	Create(employeeTerritory *entities.EmployeeTerritory) error
	Update(employeeTerritory *entities.EmployeeTerritory) error
	Delete(id int) error
}

type employeeTerritoryService struct {
	repo repositories.EmployeeTerritoryRepository
}

func NewEmployeeTerritoryService(repo repositories.EmployeeTerritoryRepository) EmployeeTerritoryService {
	return &employeeTerritoryService{repo: repo}
}

func (s *employeeTerritoryService) GetAll() ([]entities.EmployeeTerritory, error) {
	return s.repo.GetAll()
}

func (s *employeeTerritoryService) GetByID(id int) (*entities.EmployeeTerritory, error) {
	return s.repo.GetByID(id)
}

func (s *employeeTerritoryService) Create(employeeTerritory *entities.EmployeeTerritory) error {
	return s.repo.Create(employeeTerritory)
}

func (s *employeeTerritoryService) Update(employeeTerritory *entities.EmployeeTerritory) error {
	return s.repo.Update(employeeTerritory)
}

func (s *employeeTerritoryService) Delete(id int) error {
	return s.repo.Delete(id)
}
