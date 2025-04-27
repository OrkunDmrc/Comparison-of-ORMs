package repositories

import (
	"GORM_ORM/dal/entities"

	"gorm.io/gorm"
)

type RegionRepository interface {
	GetAll() ([]entities.Region, error)
	GetByID(id int) (*entities.Region, error)
	Create(entity *entities.Region) error
	Update(entity *entities.Region) error
	Delete(id int) error
}

type regionRepository struct {
	genericRepo GenericRepository[entities.Region]
}

func NewRegionRepository(db *gorm.DB) RegionRepository {
	return &regionRepository{
		genericRepo: NewGenericRepository[entities.Region](db),
	}
}

func (r *regionRepository) GetAll() ([]entities.Region, error) {
	return r.genericRepo.GetAll()
}

func (r *regionRepository) GetByID(id int) (*entities.Region, error) {
	return r.genericRepo.GetByID(id)
}

func (r *regionRepository) Create(entity *entities.Region) error {
	return r.genericRepo.Create(entity)
}

func (r *regionRepository) Update(entity *entities.Region) error {
	return r.genericRepo.Update(entity)
}

func (r *regionRepository) Delete(id int) error {
	return r.genericRepo.Delete(id)
}
