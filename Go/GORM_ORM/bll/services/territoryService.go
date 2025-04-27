package services

import (
	"GORM_ORM/dal/entities"
	"GORM_ORM/dal/repositories"
)

type TerritoryService interface {
	GetAll() ([]entities.Territory, error)
	GetByID(id string) (*entities.Territory, error)
	Create(territory *entities.Territory) error
	Update(territory *entities.Territory) error
	Delete(id string) error
}

type territoryService struct {
	repo repositories.TerritoryRepository
}

func NewTerritoryService(repo repositories.TerritoryRepository) TerritoryService {
	return &territoryService{repo: repo}
}

func (s *territoryService) GetAll() ([]entities.Territory, error) {
	return s.repo.GetAll()
}

func (s *territoryService) GetByID(id string) (*entities.Territory, error) {
	return s.repo.GetByID(id)
}

func (s *territoryService) Create(territory *entities.Territory) error {
	return s.repo.Create(territory)
}

func (s *territoryService) Update(territory *entities.Territory) error {
	return s.repo.Update(territory)
}

func (s *territoryService) Delete(id string) error {
	return s.repo.Delete(id)
}
