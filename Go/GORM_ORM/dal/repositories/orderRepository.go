package repositories

import (
	"GORM_ORM/dal/entities"

	"gorm.io/gorm"
)

type OrderRepository interface {
	GetAll() ([]entities.Order, error)
	GetByID(id int) (*entities.Order, error)
	Create(entity *entities.Order) error
	Update(entity *entities.Order) error
	Delete(id int) error
}

type orderRepository struct {
	genericRepo GenericRepository[entities.Order]
}

func NewOrderRepository(db *gorm.DB) OrderRepository {
	return &orderRepository{
		genericRepo: NewGenericRepository[entities.Order](db),
	}
}

func (r *orderRepository) GetAll() ([]entities.Order, error) {
	return r.genericRepo.GetAll()
}

func (r *orderRepository) GetByID(id int) (*entities.Order, error) {
	return r.genericRepo.GetByID(id)
}

func (r *orderRepository) Create(entity *entities.Order) error {
	return r.genericRepo.Create(entity)
}

func (r *orderRepository) Update(entity *entities.Order) error {
	return r.genericRepo.Update(entity)
}

func (r *orderRepository) Delete(id int) error {
	return r.genericRepo.Delete(id)
}
