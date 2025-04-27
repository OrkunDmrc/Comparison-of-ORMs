package services

import (
	"GORM_ORM/dal/entities"
	"GORM_ORM/dal/repositories"
)

type SupplierService interface {
	GetAll() ([]entities.Supplier, error)
	GetByID(id int) (*entities.Supplier, error)
	Create(supplier *entities.Supplier) error
	Update(supplier *entities.Supplier) error
	Delete(id int) error
}

type supplierService struct {
	repo repositories.SupplierRepository
}

func NewSupplierService(repo repositories.SupplierRepository) SupplierService {
	return &supplierService{repo: repo}
}

func (s *supplierService) GetAll() ([]entities.Supplier, error) {
	return s.repo.GetAll()
}

func (s *supplierService) GetByID(id int) (*entities.Supplier, error) {
	return s.repo.GetByID(id)
}

func (s *supplierService) Create(supplier *entities.Supplier) error {
	return s.repo.Create(supplier)
}

func (s *supplierService) Update(supplier *entities.Supplier) error {
	return s.repo.Update(supplier)
}

func (s *supplierService) Delete(id int) error {
	return s.repo.Delete(id)
}
