package services

import (
	"SQLBOILER_ORM/dal/entities"
	"SQLBOILER_ORM/dal/repositories"
	"context"
)

type EmployeeTerritoryService struct {
	repo *repositories.EmployeeTerritoryRepository
}

func NewEmployeeTerritoryService(repo *repositories.EmployeeTerritoryRepository) *EmployeeTerritoryService {
	return &EmployeeTerritoryService{repo: repo}
}

func (s *EmployeeTerritoryService) GetByEmployeeIDAndTerritoryID(ctx context.Context, employeeID int, territoryID string) (*entities.EmployeeTerritory, error) {
	employeeTerritory, err := s.repo.GetByEmployeeIDAndTerritoryID(ctx, employeeID, territoryID)
	if err != nil {
		return nil, err
	}
	return employeeTerritory, nil
}

func (s *EmployeeTerritoryService) GetAll(ctx context.Context) ([]*entities.EmployeeTerritory, error) {
	return s.repo.GetAll(ctx)
}

func (s *EmployeeTerritoryService) Create(ctx context.Context, employeeTerritory *entities.EmployeeTerritory) (*entities.EmployeeTerritory, error) {
	return s.repo.Create(ctx, employeeTerritory)
}

func (s *EmployeeTerritoryService) Delete(ctx context.Context, employeeID int, territoryID string) error {
	return s.repo.Delete(ctx, employeeID, territoryID)
}
