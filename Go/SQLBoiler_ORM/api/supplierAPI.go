package api

import (
	"net/http"
	"strconv"

	"SQLBOILER_ORM/bll/services"
	"SQLBOILER_ORM/dal/entities"

	"github.com/gin-gonic/gin"
)

type SupplierAPI struct {
	Service services.SupplierService
}

func NewSupplierAPI(s services.SupplierService) *SupplierAPI {
	return &SupplierAPI{Service: s}
}

func (h *SupplierAPI) GetAll(c *gin.Context) {
	entities, err := h.Service.GetAll(c)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, entities)
}

func (h *SupplierAPI) GetByID(c *gin.Context) {
	id, _ := strconv.Atoi(c.Param("id"))
	entity, err := h.Service.GetByID(c, id)
	if err != nil {
		c.JSON(http.StatusNotFound, gin.H{"error": "Supplier not found"})
		return
	}
	c.JSON(http.StatusOK, entity)
}

func (h *SupplierAPI) Create(c *gin.Context) {
	var entity entities.Supplier
	if err := c.ShouldBindJSON(&entity); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	supplier, err := h.Service.Create(c, &entity)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusCreated, supplier)
}

func (h *SupplierAPI) Update(c *gin.Context) {
	id, _ := strconv.Atoi(c.Param("id"))
	var entity entities.Supplier
	if err := c.ShouldBindJSON(&entity); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	entity.SupplierID = id
	if err := h.Service.Update(c, &entity); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, entity)
}

func (h *SupplierAPI) Delete(c *gin.Context) {
	id, _ := strconv.Atoi(c.Param("id"))
	if err := h.Service.Delete(c, id); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.Status(http.StatusOK)
}
