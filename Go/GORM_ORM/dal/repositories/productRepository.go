package repositories

import (
	"GORM_ORM/dal/entities"

	"gorm.io/gorm"
)

type ProductRepository interface {
	GetAll() ([]entities.Product, error)
	GetByID(id int) (*entities.Product, error)
	Create(entity *entities.Product) error
	Update(entity *entities.Product) error
	Delete(id int) error
}

type productRepository struct {
	genericRepo GenericRepository[entities.Product]
}

func NewProductRepository(db *gorm.DB) ProductRepository {
	return &productRepository{
		genericRepo: NewGenericRepository[entities.Product](db),
	}
}

func (r *productRepository) GetAll() ([]entities.Product, error) {
	return r.genericRepo.GetAll()
}

func (r *productRepository) GetByID(id int) (*entities.Product, error) {
	return r.genericRepo.GetByID(id)
}

func (r *productRepository) Create(entity *entities.Product) error {
	return r.genericRepo.Create(entity)
}

func (r *productRepository) Update(entity *entities.Product) error {
	return r.genericRepo.Update(entity)
}

func (r *productRepository) Delete(id int) error {
	return r.genericRepo.Delete(id)
}
