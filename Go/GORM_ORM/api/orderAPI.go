package api

import (
	"net/http"
	"strconv"

	"GORM_ORM/bll/services"
	"GORM_ORM/dal/entities"

	"github.com/gin-gonic/gin"
)

type OrderAPI struct {
	Service services.OrderService
}

func NewOrderAPI(s services.OrderService) *OrderAPI {
	return &OrderAPI{Service: s}
}

func (h *OrderAPI) GetAll(c *gin.Context) {
	for i := 0; i < 19; i++ {
		h.Service.GetAll()
	}
	entities, err := h.Service.GetAll()
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, entities)
}

func (h *OrderAPI) GetByID(c *gin.Context) {
	id, _ := strconv.Atoi(c.Param("id"))
	for i := 0; i < 19; i++ {
		h.Service.GetByID(id)
	}
	entity, err := h.Service.GetByID(id)
	if err != nil {
		c.JSON(http.StatusNotFound, gin.H{"error": "Order not found"})
		return
	}
	c.JSON(http.StatusOK, entity)
}

func (h *OrderAPI) Create(c *gin.Context) {
	var entity entities.Order
	if err := c.ShouldBindJSON(&entity); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	for i := 0; i < 19; i++ {
		h.Service.Create(&entity)
	}
	order, err := h.Service.Create(&entity)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusCreated, order)
}

func (h *OrderAPI) Update(c *gin.Context) {
	id, _ := strconv.Atoi(c.Param("id"))
	var entity entities.Order
	if err := c.ShouldBindJSON(&entity); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	entity.OrderID = id
	for i := 0; i < 20; i++ {
		if err := h.Service.Update(&entity); err != nil {
			c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
			return
		}
	}
	c.JSON(http.StatusOK, entity)
}

func (h *OrderAPI) Delete(c *gin.Context) {
	id, _ := strconv.Atoi(c.Param("id"))
	for i := 0; i < 20; i++ {
		if err := h.Service.Delete(id - 1); err != nil {
			c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
			return
		}
	}
	c.Status(http.StatusOK)
}

func (h *OrderAPI) AllTables(c *gin.Context) {
	for i := 0; i < 20; i++ {
		if err := h.Service.AllTables(); err != nil {
			c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
			return
		}
	}
	c.JSON(http.StatusOK, "OK")
}
