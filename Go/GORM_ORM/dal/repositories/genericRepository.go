package repositories

import (
	"gorm.io/gorm"
)

type GenericRepository[T any] interface {
	GetAll() ([]T, error)
	GetByID(id any) (*T, error)
	Create(entity *T) error
	Update(entity *T) error
	Delete(id any) error
}

type genericRepository[T any] struct {
	db *gorm.DB
}

func NewGenericRepository[T any](db *gorm.DB) GenericRepository[T] {
	return &genericRepository[T]{db: db}
}

func (r *genericRepository[T]) GetAll() ([]T, error) {
	var entities []T
	err := r.db.Find(&entities).Error
	return entities, err
}

func (r *genericRepository[T]) GetByID(id any) (*T, error) {
	var entity T
	err := r.db.First(&entity, id).Error
	if err != nil {
		return nil, err
	}
	return &entity, nil
}

func (r *genericRepository[T]) Create(entity *T) error {
	return r.db.Create(entity).Error
}

func (r *genericRepository[T]) Update(entity *T) error {
	return r.db.Save(entity).Error
}

func (r *genericRepository[T]) Delete(id any) error {
	var entity T
	return r.db.Delete(&entity, id).Error
}
