package api

import (
	"net/http"
	"strconv"

	"SQLBOILER_ORM/bll/services"
	"SQLBOILER_ORM/dal/entities"

	"github.com/gin-gonic/gin"
)

type OrderAPI struct {
	Service services.OrderService
}

func NewOrderAPI(s services.OrderService) *OrderAPI {
	return &OrderAPI{Service: s}
}

func (h *OrderAPI) GetAll(c *gin.Context) {
	entities, err := h.Service.GetAll(c)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, entities)
}

func (h *OrderAPI) GetByID(c *gin.Context) {
	id, _ := strconv.Atoi(c.Param("id"))
	entity, err := h.Service.GetByID(c, id)
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
	order, err := h.Service.Create(c, &entity)
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
	if err := h.Service.Update(c, &entity); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, entity)
}

func (h *OrderAPI) Delete(c *gin.Context) {
	id, _ := strconv.Atoi(c.Param("id"))
	if err := h.Service.Delete(c, id); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.Status(http.StatusOK)
}
