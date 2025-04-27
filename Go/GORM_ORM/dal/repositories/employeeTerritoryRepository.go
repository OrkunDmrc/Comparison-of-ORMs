package repositories

import (
	"GORM_ORM/dal/entities"

	"gorm.io/gorm"
)

type EmployeeTerritoryRepository interface {
	GetAll() ([]entities.EmployeeTerritory, error)
	GetByID(id int) (*entities.EmployeeTerritory, error)
	Create(entity *entities.EmployeeTerritory) error
	Update(entity *entities.EmployeeTerritory) error
	Delete(id int) error
}

type employeeTerrirtoryRepository struct {
	genericRepo GenericRepository[entities.EmployeeTerritory]
}

func NewEmployeeTerritoryRepository(db *gorm.DB) EmployeeTerritoryRepository {
	return &employeeTerrirtoryRepository{
		genericRepo: NewGenericRepository[entities.EmployeeTerritory](db),
	}
}

func (r *employeeTerrirtoryRepository) GetAll() ([]entities.EmployeeTerritory, error) {
	return r.genericRepo.GetAll()
}

func (r *employeeTerrirtoryRepository) GetByID(id int) (*entities.EmployeeTerritory, error) {
	return r.genericRepo.GetByID(id)
}

func (r *employeeTerrirtoryRepository) Create(entity *entities.EmployeeTerritory) error {
	return r.genericRepo.Create(entity)
}

func (r *employeeTerrirtoryRepository) Update(entity *entities.EmployeeTerritory) error {
	return r.genericRepo.Update(entity)
}

func (r *employeeTerrirtoryRepository) Delete(id int) error {
	return r.genericRepo.Delete(id)
}
