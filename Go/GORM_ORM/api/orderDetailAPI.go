package api

import (
	"net/http"
	"strconv"

	"GORM_ORM/bll/services"
	"GORM_ORM/dal/entities"

	"github.com/gin-gonic/gin"
)

type OrderDetailAPI struct {
	Service services.OrderDetailService
}

func NewOrderDetailAPI(s services.OrderDetailService) *OrderDetailAPI {
	return &OrderDetailAPI{Service: s}
}

func (h *OrderDetailAPI) GetAll(c *gin.Context) {
	entities, err := h.Service.GetAll()
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, entities)
}

func (h *OrderDetailAPI) GetByID(c *gin.Context) {
	orderId, _ := strconv.Atoi(c.Param("orderId"))
	productId, _ := strconv.Atoi(c.Param("productId"))
	entity, err := h.Service.GetByID(orderId, productId)
	if err != nil {
		c.JSON(http.StatusNotFound, gin.H{"error": "OrderDetail not found"})
		return
	}
	c.JSON(http.StatusOK, entity)
}

func (h *OrderDetailAPI) Create(c *gin.Context) {
	var entity entities.OrderDetail
	if err := c.ShouldBindJSON(&entity); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	if err := h.Service.Create(&entity); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusCreated, entity)
}

func (h *OrderDetailAPI) Delete(c *gin.Context) {
	orderId, _ := strconv.Atoi(c.Param("orderId"))
	productId, _ := strconv.Atoi(c.Param("productId"))
	if err := h.Service.Delete(orderId, productId); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.Status(http.StatusOK)
}
