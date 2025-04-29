package services

import (
	"SQLBOILER_ORM/dal/entities"
	"SQLBOILER_ORM/dal/repositories"
	"context"
)

type SupplierService struct {
	repo *repositories.SupplierRepository
}

func NewSupplierService(repo *repositories.SupplierRepository) *SupplierService {
	return &SupplierService{repo: repo}
}

func (s *SupplierService) GetByID(ctx context.Context, id int) (*entities.Supplier, error) {
	shipper, err := s.repo.GetByID(ctx, id)
	if err != nil {
		return nil, err
	}
	return shipper, nil
}

func (s *SupplierService) GetAll(ctx context.Context) ([]*entities.Supplier, error) {
	return s.repo.GetAll(ctx)
}

func (s *SupplierService) Create(ctx context.Context, shipper *entities.Supplier) (*entities.Supplier, error) {
	return s.repo.Create(ctx, shipper)
}

func (s *SupplierService) Update(ctx context.Context, shipper *entities.Supplier) error {
	return s.repo.Update(ctx, shipper)
}

func (s *SupplierService) Delete(ctx context.Context, id int) error {
	return s.repo.Delete(ctx, id)
}
