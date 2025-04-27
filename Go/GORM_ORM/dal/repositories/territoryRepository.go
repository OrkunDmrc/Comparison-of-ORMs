package repositories

import (
	"GORM_ORM/dal/entities"

	"gorm.io/gorm"
)

type TerritoryRepository interface {
	GetAll() ([]entities.Territory, error)
	GetByID(id string) (*entities.Territory, error)
	Create(entity *entities.Territory) error
	Update(entity *entities.Territory) error
	Delete(id string) error
}

type territoryRepository struct {
	genericRepo GenericRepository[entities.Territory]
}

func NewTerritoryRepository(db *gorm.DB) TerritoryRepository {
	return &territoryRepository{
		genericRepo: NewGenericRepository[entities.Territory](db),
	}
}

func (r *territoryRepository) GetAll() ([]entities.Territory, error) {
	return r.genericRepo.GetAll()
}

func (r *territoryRepository) GetByID(id string) (*entities.Territory, error) {
	return r.genericRepo.GetByID(id)
}

func (r *territoryRepository) Create(entity *entities.Territory) error {
	return r.genericRepo.Create(entity)
}

func (r *territoryRepository) Update(entity *entities.Territory) error {
	return r.genericRepo.Update(entity)
}

func (r *territoryRepository) Delete(id string) error {
	return r.genericRepo.Delete(id)
}
