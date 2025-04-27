package repositories

import (
	"GORM_ORM/dal/entities"

	"gorm.io/gorm"
)

type CustomerRepository interface {
	GetAll() ([]entities.Customer, error)
	GetByID(id string) (*entities.Customer, error)
	Create(entity *entities.Customer) error
	Update(entity *entities.Customer) error
	Delete(id string) error
}

type customerRepository struct {
	genericRepo GenericRepository[entities.Customer]
}

func NewCustomerRepository(db *gorm.DB) CustomerRepository {
	return &customerRepository{
		genericRepo: NewGenericRepository[entities.Customer](db),
	}
}

func (r *customerRepository) GetAll() ([]entities.Customer, error) {
	return r.genericRepo.GetAll()
}

func (r *customerRepository) GetByID(id string) (*entities.Customer, error) {
	return r.genericRepo.GetByID(id)
}

func (r *customerRepository) Create(entity *entities.Customer) error {
	return r.genericRepo.Create(entity)
}

func (r *customerRepository) Update(entity *entities.Customer) error {
	return r.genericRepo.Update(entity)
}

func (r *customerRepository) Delete(id string) error {
	return r.genericRepo.Delete(id)
}
