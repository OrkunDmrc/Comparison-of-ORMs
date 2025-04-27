package repositories

import (
	"GORM_ORM/dal/entities"

	"gorm.io/gorm"
)

type SupplierRepository interface {
	GetAll() ([]entities.Supplier, error)
	GetByID(id int) (*entities.Supplier, error)
	Create(entity *entities.Supplier) error
	Update(entity *entities.Supplier) error
	Delete(id int) error
}

type supplierRepository struct {
	genericRepo GenericRepository[entities.Supplier]
}

func NewSupplierRepository(db *gorm.DB) SupplierRepository {
	return &supplierRepository{
		genericRepo: NewGenericRepository[entities.Supplier](db),
	}
}

func (r *supplierRepository) GetAll() ([]entities.Supplier, error) {
	return r.genericRepo.GetAll()
}

func (r *supplierRepository) GetByID(id int) (*entities.Supplier, error) {
	return r.genericRepo.GetByID(id)
}

func (r *supplierRepository) Create(entity *entities.Supplier) error {
	return r.genericRepo.Create(entity)
}

func (r *supplierRepository) Update(entity *entities.Supplier) error {
	return r.genericRepo.Update(entity)
}

func (r *supplierRepository) Delete(id int) error {
	return r.genericRepo.Delete(id)
}
