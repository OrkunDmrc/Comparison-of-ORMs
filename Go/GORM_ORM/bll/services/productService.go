package services

import (
	"GORM_ORM/dal/entities"
	"GORM_ORM/dal/repositories"
)

type ProductService interface {
	GetAll() ([]entities.Product, error)
	GetByID(id int) (*entities.Product, error)
	Create(product *entities.Product) error
	Update(product *entities.Product) error
	Delete(id int) error
}

type productService struct {
	repo repositories.ProductRepository
}

func NewProductService(repo repositories.ProductRepository) ProductService {
	return &productService{repo: repo}
}

func (s *productService) GetAll() ([]entities.Product, error) {
	return s.repo.GetAll()
}

func (s *productService) GetByID(id int) (*entities.Product, error) {
	return s.repo.GetByID(id)
}

func (s *productService) Create(product *entities.Product) error {
	return s.repo.Create(product)
}

func (s *productService) Update(product *entities.Product) error {
	return s.repo.Update(product)
}

func (s *productService) Delete(id int) error {
	return s.repo.Delete(id)
}
