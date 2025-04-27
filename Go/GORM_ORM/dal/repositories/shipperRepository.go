package repositories

import (
	"GORM_ORM/dal/entities"

	"gorm.io/gorm"
)

type ShipperRepository interface {
	GetAll() ([]entities.Shipper, error)
	GetByID(id int) (*entities.Shipper, error)
	Create(entity *entities.Shipper) error
	Update(entity *entities.Shipper) error
	Delete(id int) error
}

type shipperRepository struct {
	genericRepo GenericRepository[entities.Shipper]
}

func NewShipperRepository(db *gorm.DB) ShipperRepository {
	return &shipperRepository{
		genericRepo: NewGenericRepository[entities.Shipper](db),
	}
}

func (r *shipperRepository) GetAll() ([]entities.Shipper, error) {
	return r.genericRepo.GetAll()
}

func (r *shipperRepository) GetByID(id int) (*entities.Shipper, error) {
	return r.genericRepo.GetByID(id)
}

func (r *shipperRepository) Create(entity *entities.Shipper) error {
	return r.genericRepo.Create(entity)
}

func (r *shipperRepository) Update(entity *entities.Shipper) error {
	return r.genericRepo.Update(entity)
}

func (r *shipperRepository) Delete(id int) error {
	return r.genericRepo.Delete(id)
}
