package services

import (
	"GORM_ORM/dal/entities"
	"GORM_ORM/dal/repositories"
)

type ShipperService interface {
	GetAll() ([]entities.Shipper, error)
	GetByID(id int) (*entities.Shipper, error)
	Create(shipper *entities.Shipper) error
	Update(shipper *entities.Shipper) error
	Delete(id int) error
}

type shipperService struct {
	repo repositories.ShipperRepository
}

func NewShipperService(repo repositories.ShipperRepository) ShipperService {
	return &shipperService{repo: repo}
}

func (s *shipperService) GetAll() ([]entities.Shipper, error) {
	return s.repo.GetAll()
}

func (s *shipperService) GetByID(id int) (*entities.Shipper, error) {
	return s.repo.GetByID(id)
}

func (s *shipperService) Create(shipper *entities.Shipper) error {
	return s.repo.Create(shipper)
}

func (s *shipperService) Update(shipper *entities.Shipper) error {
	return s.repo.Update(shipper)
}

func (s *shipperService) Delete(id int) error {
	return s.repo.Delete(id)
}
