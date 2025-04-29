package api

import (
	"net/http"
	"strconv"

	"SQLBOILER_ORM/bll/services"
	"SQLBOILER_ORM/dal/entities"

	"github.com/gin-gonic/gin"
)

type OrderDetailAPI struct {
	Service services.OrderDetailService
}

func NewOrderDetailAPI(s services.OrderDetailService) *OrderDetailAPI {
	return &OrderDetailAPI{Service: s}
}

func (h *OrderDetailAPI) GetAll(c *gin.Context) {
	entities, err := h.Service.GetAll(c)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, entities)
}

func (h *OrderDetailAPI) GetByOrderIDAndProductID(c *gin.Context) {
	orderID, _ := strconv.Atoi(c.Param("orderId"))
	productID, _ := strconv.Atoi(c.Param("productId"))
	entity, err := h.Service.GetByOrderIDAndProductID(c, orderID, productID)
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
	orderDetail, err := h.Service.Create(c, &entity)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusCreated, orderDetail)
}

func (h *OrderDetailAPI) Update(c *gin.Context) {
	orderID, _ := strconv.Atoi(c.Param("orderId"))
	productID, _ := strconv.Atoi(c.Param("productId"))
	var entity entities.OrderDetail
	if err := c.ShouldBindJSON(&entity); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	entity.OrderID = orderID
	entity.ProductID = productID
	if err := h.Service.Update(c, &entity); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, entity)
}

func (h *OrderDetailAPI) Delete(c *gin.Context) {
	orderID, _ := strconv.Atoi(c.Param("orderId"))
	productID, _ := strconv.Atoi(c.Param("productId"))
	if err := h.Service.Delete(c, orderID, productID); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.Status(http.StatusOK)
}
