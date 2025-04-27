package services

import (
	"GORM_ORM/dal/entities"
	"GORM_ORM/dal/repositories"
)

type CategoryService interface {
	GetAll() ([]entities.Category, error)
	GetByID(id int) (*entities.Category, error)
	Create(category *entities.Category) error
	Update(category *entities.Category) error
	Delete(id int) error
}

type categoryService struct {
	repo repositories.CategoryRepository
}

func NewCategoryService(repo repositories.CategoryRepository) CategoryService {
	return &categoryService{repo: repo}
}

func (s *categoryService) GetAll() ([]entities.Category, error) {
	return s.repo.GetAll()
}

func (s *categoryService) GetByID(id int) (*entities.Category, error) {
	return s.repo.GetByID(id)
}

func (s *categoryService) Create(category *entities.Category) error {
	return s.repo.Create(category)
}

func (s *categoryService) Update(category *entities.Category) error {
	return s.repo.Update(category)
}

func (s *categoryService) Delete(id int) error {
	return s.repo.Delete(id)
}
