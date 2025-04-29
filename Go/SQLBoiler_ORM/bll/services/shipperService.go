package services

import (
	"SQLBOILER_ORM/dal/entities"
	"SQLBOILER_ORM/dal/repositories"
	"context"
)

type ShipperService struct {
	repo *repositories.ShipperRepository
}

func NewShipperService(repo *repositories.ShipperRepository) *ShipperService {
	return &ShipperService{repo: repo}
}

func (s *ShipperService) GetByID(ctx context.Context, id int) (*entities.Shipper, error) {
	shipper, err := s.repo.GetByID(ctx, id)
	if err != nil {
		return nil, err
	}
	return shipper, nil
}

func (s *ShipperService) GetAll(ctx context.Context) ([]*entities.Shipper, error) {
	return s.repo.GetAll(ctx)
}

func (s *ShipperService) Create(ctx context.Context, shipper *entities.Shipper) (*entities.Shipper, error) {
	return s.repo.Create(ctx, shipper)
}

func (s *ShipperService) Update(ctx context.Context, shipper *entities.Shipper) error {
	return s.repo.Update(ctx, shipper)
}

func (s *ShipperService) Delete(ctx context.Context, id int) error {
	return s.repo.Delete(ctx, id)
}
