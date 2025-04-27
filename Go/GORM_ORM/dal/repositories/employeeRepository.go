package repositories

import (
	"GORM_ORM/dal/entities"

	"gorm.io/gorm"
)

type EmployeeRepository interface {
	GetAll() ([]entities.Employee, error)
	GetByID(id int) (*entities.Employee, error)
	Create(entity *entities.Employee) error
	Update(entity *entities.Employee) error
	Delete(id int) error
}

type employeeRepository struct {
	genericRepo GenericRepository[entities.Employee]
}

func NewEmployeeRepository(db *gorm.DB) EmployeeRepository {
	return &employeeRepository{
		genericRepo: NewGenericRepository[entities.Employee](db),
	}
}

func (r *employeeRepository) GetAll() ([]entities.Employee, error) {
	return r.genericRepo.GetAll()
}

func (r *employeeRepository) GetByID(id int) (*entities.Employee, error) {
	return r.genericRepo.GetByID(id)
}

func (r *employeeRepository) Create(entity *entities.Employee) error {
	return r.genericRepo.Create(entity)
}

func (r *employeeRepository) Update(entity *entities.Employee) error {
	return r.genericRepo.Update(entity)
}

func (r *employeeRepository) Delete(id int) error {
	return r.genericRepo.Delete(id)
}
