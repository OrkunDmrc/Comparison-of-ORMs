package repositories

import (
	"GORM_ORM/dal/entities"

	"gorm.io/gorm"
)

type OrderRepository interface {
	GetAll() ([]entities.Order, error)
	GetByID(id int) (*entities.Order, error)
	Create(entity *entities.Order) (*entities.Order, error)
	Update(entity *entities.Order) error
	Delete(id int) error
}

type orderRepository struct {
	//genericRepo GenericRepository[entities.Order]
	db *gorm.DB
}

func NewOrderRepository(db *gorm.DB) OrderRepository {
	return &orderRepository{
		//genericRepo: NewGenericRepository[entities.Order](db),
		db: db,
	}
}

func (r *orderRepository) GetAll() ([]entities.Order, error) {
	var entities []entities.Order
	err := r.db.Find(&entities).Error
	return entities, err
}

func (r *orderRepository) GetByID(id int) (*entities.Order, error) {
	var entity entities.Order
	err := r.db.First(&entity, id).Error
	if err != nil {
		return nil, err
	}
	return &entity, nil
}

func (r *orderRepository) Create(entity *entities.Order) (*entities.Order, error) {
	err := r.db.Create(entity).Error
	if err != nil {
		return nil, err
	}
	return entity, nil
}

func (r *orderRepository) Update(entity *entities.Order) error {
	return r.db.Save(entity).Error
}

func (r *orderRepository) Delete(id int) error {
	var entity entities.Order
	return r.db.Delete(&entity, id).Error
}
