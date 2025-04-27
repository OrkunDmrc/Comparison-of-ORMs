package api

import (
	"net/http"

	"GORM_ORM/bll/services"
	"GORM_ORM/dal/entities"

	"github.com/gin-gonic/gin"
)

type CustomerAPI struct {
	Service services.CustomerService
}

func NewCustomerAPI(s services.CustomerService) *CustomerAPI {
	return &CustomerAPI{Service: s}
}

func (h *CustomerAPI) GetAll(c *gin.Context) {
	entities, err := h.Service.GetAll()
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, entities)
}

func (h *CustomerAPI) GetByID(c *gin.Context) {
	id := c.Param("id")
	entity, err := h.Service.GetByID(id)
	if err != nil {
		c.JSON(http.StatusNotFound, gin.H{"error": "Customer not found"})
		return
	}
	c.JSON(http.StatusOK, entity)
}

func (h *CustomerAPI) Create(c *gin.Context) {
	var entity entities.Customer
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

func (h *CustomerAPI) Update(c *gin.Context) {
	id := c.Param("id")
	var entity entities.Customer
	if err := c.ShouldBindJSON(&entity); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	entity.CustomerID = id
	if err := h.Service.Update(&entity); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, entity)
}

func (h *CustomerAPI) Delete(c *gin.Context) {
	id := c.Param("id")
	if err := h.Service.Delete(id); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.Status(http.StatusOK)
}
