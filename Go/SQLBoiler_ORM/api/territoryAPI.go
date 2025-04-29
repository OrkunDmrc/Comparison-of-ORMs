package api

import (
	"net/http"

	"SQLBOILER_ORM/bll/services"
	"SQLBOILER_ORM/dal/entities"

	"github.com/gin-gonic/gin"
)

type TerritoryAPI struct {
	Service services.TerritoryService
}

func NewTerritoryAPI(s services.TerritoryService) *TerritoryAPI {
	return &TerritoryAPI{Service: s}
}

func (h *TerritoryAPI) GetAll(c *gin.Context) {
	entities, err := h.Service.GetAll(c)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, entities)
}

func (h *TerritoryAPI) GetByID(c *gin.Context) {
	id := c.Param("id")
	entity, err := h.Service.GetByID(c, id)
	if err != nil {
		c.JSON(http.StatusNotFound, gin.H{"error": "Territory not found"})
		return
	}
	c.JSON(http.StatusOK, entity)
}

func (h *TerritoryAPI) Create(c *gin.Context) {
	var entity entities.Territory
	if err := c.ShouldBindJSON(&entity); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	territory, err := h.Service.Create(c, &entity)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusCreated, territory)
}

func (h *TerritoryAPI) Update(c *gin.Context) {
	id := c.Param("id")
	var entity entities.Territory
	if err := c.ShouldBindJSON(&entity); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	entity.TerritoryID = id
	if err := h.Service.Update(c, &entity); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, entity)
}

func (h *TerritoryAPI) Delete(c *gin.Context) {
	id := c.Param("id")
	if err := h.Service.Delete(c, id); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.Status(http.StatusOK)
}
