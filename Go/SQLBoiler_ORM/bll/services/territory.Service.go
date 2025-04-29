package services

import (
	"SQLBOILER_ORM/dal/entities"
	"SQLBOILER_ORM/dal/repositories"
	"context"
)

type TerritoryService struct {
	repo *repositories.TerritoryRepository
}

func NewTerritoryService(repo *repositories.TerritoryRepository) *TerritoryService {
	return &TerritoryService{repo: repo}
}

func (s *TerritoryService) GetByID(ctx context.Context, id string) (*entities.Territory, error) {
	territory, err := s.repo.GetByID(ctx, id)
	if err != nil {
		return nil, err
	}
	return territory, nil
}

func (s *TerritoryService) GetAll(ctx context.Context) ([]*entities.Territory, error) {
	return s.repo.GetAll(ctx)
}

func (s *TerritoryService) Create(ctx context.Context, territory *entities.Territory) (*entities.Territory, error) {
	return s.repo.Create(ctx, territory)
}

func (s *TerritoryService) Update(ctx context.Context, territory *entities.Territory) error {
	return s.repo.Update(ctx, territory)
}

func (s *TerritoryService) Delete(ctx context.Context, id string) error {
	return s.repo.Delete(ctx, id)
}
