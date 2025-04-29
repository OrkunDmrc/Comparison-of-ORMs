package api

import (
	"net/http"
	"strconv"

	"SQLBOILER_ORM/bll/services"
	"SQLBOILER_ORM/dal/entities"

	"github.com/gin-gonic/gin"
)

type EmployeeTerritoryAPI struct {
	Service services.EmployeeTerritoryService
}

func NewEmployeeTerritoryAPI(s services.EmployeeTerritoryService) *EmployeeTerritoryAPI {
	return &EmployeeTerritoryAPI{Service: s}
}

func (h *EmployeeTerritoryAPI) GetAll(c *gin.Context) {
	entities, err := h.Service.GetAll(c)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, entities)
}

func (h *EmployeeTerritoryAPI) GetByEmployeeIDAndTerritoryID(c *gin.Context) {
	employeeID, _ := strconv.Atoi(c.Param("employeeId"))
	territoryID := c.Param("territoryId")
	entity, err := h.Service.GetByEmployeeIDAndTerritoryID(c, employeeID, territoryID)
	if err != nil {
		c.JSON(http.StatusNotFound, gin.H{"error": "EmployeeTerritory not found"})
		return
	}
	c.JSON(http.StatusOK, entity)
}

func (h *EmployeeTerritoryAPI) Create(c *gin.Context) {
	var entity entities.EmployeeTerritory
	if err := c.ShouldBindJSON(&entity); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	employeeTerritory, err := h.Service.Create(c, &entity)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusCreated, employeeTerritory)
}

func (h *EmployeeTerritoryAPI) Delete(c *gin.Context) {
	employeeID, _ := strconv.Atoi(c.Param("employeeId"))
	territoryID := c.Param("territoryId")
	if err := h.Service.Delete(c, employeeID, territoryID); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.Status(http.StatusOK)
}
