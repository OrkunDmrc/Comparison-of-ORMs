package api

import (
	"net/http"
	"strconv"

	"SQLBOILER_ORM/bll/services"
	"SQLBOILER_ORM/dal/entities"

	"github.com/gin-gonic/gin"
)

type CategoryAPI struct {
	Service services.CategoryService
}

func NewCategoryAPI(s services.CategoryService) *CategoryAPI {
	return &CategoryAPI{Service: s}
}

func (h *CategoryAPI) GetAll(c *gin.Context) {
	entities, err := h.Service.GetAll(c)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, entities)
}

func (h *CategoryAPI) GetByID(c *gin.Context) {
	id, _ := strconv.Atoi(c.Param("id"))
	entity, err := h.Service.GetByID(c, id)
	if err != nil {
		c.JSON(http.StatusNotFound, gin.H{"error": "Category not found"})
		return
	}
	c.JSON(http.StatusOK, entity)
}

func (h *CategoryAPI) Create(c *gin.Context) {
	var entity entities.Category
	if err := c.ShouldBindJSON(&entity); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	category, err := h.Service.Create(c, &entity)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusCreated, category)
}

func (h *CategoryAPI) Update(c *gin.Context) {
	id, _ := strconv.Atoi(c.Param("id"))
	var entity entities.Category
	if err := c.ShouldBindJSON(&entity); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	entity.CategoryID = id
	if err := h.Service.Update(c, &entity); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, entity)
}

func (h *CategoryAPI) Delete(c *gin.Context) {
	id, _ := strconv.Atoi(c.Param("id"))
	if err := h.Service.Delete(c, id); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.Status(http.StatusOK)
}
