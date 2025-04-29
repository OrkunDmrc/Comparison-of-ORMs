package services

import (
	"SQLBOILER_ORM/dal/entities"
	"SQLBOILER_ORM/dal/repositories"
	"context"
)

type RegionService struct {
	repo *repositories.RegionRepository
}

func NewRegionService(repo *repositories.RegionRepository) *RegionService {
	return &RegionService{repo: repo}
}

func (s *RegionService) GetByID(ctx context.Context, id int) (*entities.Region, error) {
	region, err := s.repo.GetByID(ctx, id)
	if err != nil {
		return nil, err
	}
	return region, nil
}

func (s *RegionService) GetAll(ctx context.Context) ([]*entities.Region, error) {
	return s.repo.GetAll(ctx)
}

func (s *RegionService) Create(ctx context.Context, region *entities.Region) (*entities.Region, error) {
	return s.repo.Create(ctx, region)
}

func (s *RegionService) Update(ctx context.Context, region *entities.Region) error {
	return s.repo.Update(ctx, region)
}

func (s *RegionService) Delete(ctx context.Context, id int) error {
	return s.repo.Delete(ctx, id)
}
