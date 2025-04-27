package repositories

import (
	"GORM_ORM/dal/entities"

	"gorm.io/gorm"
)

type CategoryRepository interface {
	GetAll() ([]entities.Category, error)
	GetByID(id int) (*entities.Category, error)
	Create(entity *entities.Category) error
	Update(entity *entities.Category) error
	Delete(id int) error
}

type categoryRepository struct {
	genericRepo GenericRepository[entities.Category]
}

func NewCategoryRepository(db *gorm.DB) CategoryRepository {
	return &categoryRepository{
		genericRepo: NewGenericRepository[entities.Category](db),
	}
}

func (r *categoryRepository) GetAll() ([]entities.Category, error) {
	return r.genericRepo.GetAll()
}

func (r *categoryRepository) GetByID(id int) (*entities.Category, error) {
	return r.genericRepo.GetByID(id)
}

func (r *categoryRepository) Create(entity *entities.Category) error {
	return r.genericRepo.Create(entity)
}

func (r *categoryRepository) Update(entity *entities.Category) error {
	return r.genericRepo.Update(entity)
}

func (r *categoryRepository) Delete(id int) error {
	return r.genericRepo.Delete(id)
}
