package repositories

import (
	"GORM_ORM/dal/entities"

	"gorm.io/gorm"
)

type OrderDetailRepository interface {
	GetAll() ([]entities.OrderDetail, error)
	GetByID(orderId int, productId int) (*entities.OrderDetail, error)
	Create(entity *entities.OrderDetail) error
	Delete(orderId int, productId int) error
}

type orderDetailRepository struct {
	db *gorm.DB
}

func NewOrderDetailRepository(db *gorm.DB) OrderDetailRepository {
	return &orderDetailRepository{db: db}
}

func (r *orderDetailRepository) GetAll() ([]entities.OrderDetail, error) {
	var orderDetails []entities.OrderDetail
	err := r.db.Find(&orderDetails).Error
	return orderDetails, err
}

func (r *orderDetailRepository) GetByID(orderId int, productId int) (*entities.OrderDetail, error) {
	var orderDetail entities.OrderDetail
	err := r.db.Where("orderID = ? AND productID = ?", orderId, productId).First(&orderDetail).Error
	return &orderDetail, err
}

func (r *orderDetailRepository) Create(entity *entities.OrderDetail) error {
	return r.db.Create(entity).Error
}

func (r *orderDetailRepository) Delete(orderId int, productId int) error {
	return r.db.Delete(&entities.OrderDetail{}, "orderID = ? AND productID = ?", orderId, productId).Error
}
