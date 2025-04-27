package services

import (
	"GORM_ORM/dal/entities"
	"GORM_ORM/dal/repositories"
)

type RegionService interface {
	GetAll() ([]entities.Region, error)
	GetByID(id int) (*entities.Region, error)
	Create(region *entities.Region) error
	Update(region *entities.Region) error
	Delete(id int) error
}

type regionService struct {
	repo repositories.RegionRepository
}

func NewRegionService(repo repositories.RegionRepository) RegionService {
	return &regionService{repo: repo}
}

func (s *regionService) GetAll() ([]entities.Region, error) {
	return s.repo.GetAll()
}

func (s *regionService) GetByID(id int) (*entities.Region, error) {
	return s.repo.GetByID(id)
}

func (s *regionService) Create(region *entities.Region) error {
	return s.repo.Create(region)
}

func (s *regionService) Update(region *entities.Region) error {
	return s.repo.Update(region)
}

func (s *regionService) Delete(id int) error {
	return s.repo.Delete(id)
}
