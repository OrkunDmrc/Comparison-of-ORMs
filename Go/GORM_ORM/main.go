package main

import (
	"GORM_ORM/api"
	"GORM_ORM/bll/services"
	"GORM_ORM/dal/repositories"
	"os"

	"log"

	"github.com/gin-gonic/gin"
	"github.com/joho/godotenv"
	"gorm.io/driver/sqlserver"
	"gorm.io/gorm"
)

func main() {
	err := godotenv.Load()
	if err != nil {
		log.Fatalf("Error loading .env file: %v", err)
	}

	dsn := os.Getenv("DATABASE_URL")
	port := os.Getenv("PORT")
	db, err := gorm.Open(sqlserver.Open(dsn), &gorm.Config{})
	if err != nil {
		log.Fatalf("Failed to connect to DB: %v", err)
	}

	router := gin.Default()

	categoryRepo := repositories.NewCategoryRepository(db)
	categoryService := services.NewCategoryService(categoryRepo)
	categoryAPI := api.NewCategoryAPI(categoryService)
	categoryGroup := router.Group("/categories")
	{
		categoryGroup.GET("/", categoryAPI.GetAll)
		categoryGroup.GET("/:id", categoryAPI.GetByID)
		categoryGroup.POST("/", categoryAPI.Create)
		categoryGroup.PUT("/:id", categoryAPI.Update)
		categoryGroup.DELETE("/:id", categoryAPI.Delete)
	}

	customerRepo := repositories.NewCustomerRepository(db)
	customerService := services.NewCustomerService(customerRepo)
	customerAPI := api.NewCustomerAPI(customerService)
	customerGroup := router.Group("/customers")
	{
		customerGroup.GET("/", customerAPI.GetAll)
		customerGroup.GET("/:id", customerAPI.GetByID)
		customerGroup.POST("/", customerAPI.Create)
		customerGroup.PUT("/:id", customerAPI.Update)
		customerGroup.DELETE("/:id", customerAPI.Delete)
	}

	employeeRepo := repositories.NewEmployeeRepository(db)
	employeeService := services.NewEmployeeService(employeeRepo)
	employeeAPI := api.NewEmployeeAPI(employeeService)
	employeeGroup := router.Group("/employees")
	{
		employeeGroup.GET("/", employeeAPI.GetAll)
		employeeGroup.GET("/:id", employeeAPI.GetByID)
		employeeGroup.POST("/", employeeAPI.Create)
		employeeGroup.PUT("/:id", employeeAPI.Update)
		employeeGroup.DELETE("/:id", employeeAPI.Delete)
	}

	employeeTerritoryRepo := repositories.NewEmployeeTerritoryRepository(db)
	employeeTerritoryService := services.NewEmployeeTerritoryService(employeeTerritoryRepo)
	employeeTerritoryAPI := api.NewEmployeeTerritoryAPI(employeeTerritoryService)
	employeeTerritoryGroup := router.Group("/employeeTerritories")
	{
		employeeTerritoryGroup.GET("/", employeeTerritoryAPI.GetAll)
		employeeTerritoryGroup.GET("/:id", employeeTerritoryAPI.GetByID)
		employeeTerritoryGroup.POST("/", employeeTerritoryAPI.Create)
		employeeTerritoryGroup.PUT("/:id", employeeTerritoryAPI.Update)
		employeeTerritoryGroup.DELETE("/:id", employeeTerritoryAPI.Delete)
	}

	testDataRepo := repositories.NewTestDataRepository(db)
	testDataService := services.NewTestDataService(testDataRepo)
	testDataAPI := api.NewTestDataAPI(testDataService)
	testDataGroup := router.Group("/testData")
	{
		testDataGroup.GET("/", testDataAPI.GetAll)
		testDataGroup.GET("/:id", testDataAPI.GetByID)
		testDataGroup.POST("/", testDataAPI.Create)
		testDataGroup.PUT("/:id", testDataAPI.Update)
		testDataGroup.DELETE("/:id", testDataAPI.Delete)
	}

	orderRepo := repositories.NewOrderRepository(db, testDataRepo)
	orderService := services.NewOrderService(orderRepo)
	orderAPI := api.NewOrderAPI(orderService)
	orderGroup := router.Group("/orders")
	{
		orderGroup.GET("/", orderAPI.GetAll)
		orderGroup.GET("/:id", orderAPI.GetByID)
		orderGroup.POST("/", orderAPI.Create)
		orderGroup.PUT("/:id", orderAPI.Update)
		orderGroup.DELETE("/:id", orderAPI.Delete)
	}

	orderDetailRepo := repositories.NewOrderDetailRepository(db)
	orderDetailService := services.NewOrderDetailService(orderDetailRepo)
	orderDetailAPI := api.NewOrderDetailAPI(orderDetailService)
	orderDetailGroup := router.Group("/orderDetails")
	{
		orderDetailGroup.GET("/", orderDetailAPI.GetAll)
		orderDetailGroup.GET("/:orderId/:productId", orderDetailAPI.GetByID)
		orderDetailGroup.POST("/", orderDetailAPI.Create)
		orderDetailGroup.DELETE("/:orderId/:productId", orderDetailAPI.Delete)
	}

	productRepo := repositories.NewProductRepository(db)
	productService := services.NewProductService(productRepo)
	productAPI := api.NewProductAPI(productService)
	productGroup := router.Group("/products")
	{
		productGroup.GET("/", productAPI.GetAll)
		productGroup.GET("/:id", productAPI.GetByID)
		productGroup.POST("/", productAPI.Create)
		productGroup.PUT("/:id", productAPI.Update)
		productGroup.DELETE("/:id", productAPI.Delete)
	}

	regionRepo := repositories.NewRegionRepository(db)
	regionService := services.NewRegionService(regionRepo)
	regionAPI := api.NewRegionAPI(regionService)
	regionGroup := router.Group("/regions")
	{
		regionGroup.GET("/", regionAPI.GetAll)
		regionGroup.GET("/:id", regionAPI.GetByID)
		regionGroup.POST("/", regionAPI.Create)
		regionGroup.PUT("/:id", regionAPI.Update)
		regionGroup.DELETE("/:id", regionAPI.Delete)
	}

	shipperRepo := repositories.NewShipperRepository(db)
	shipperService := services.NewShipperService(shipperRepo)
	shipperAPI := api.NewShipperAPI(shipperService)
	shipperGroup := router.Group("/shippers")
	{
		shipperGroup.GET("/", shipperAPI.GetAll)
		shipperGroup.GET("/:id", shipperAPI.GetByID)
		shipperGroup.POST("/", shipperAPI.Create)
		shipperGroup.PUT("/:id", shipperAPI.Update)
		shipperGroup.DELETE("/:id", shipperAPI.Delete)
	}

	supplierRepo := repositories.NewSupplierRepository(db)
	supplierService := services.NewSupplierService(supplierRepo)
	supplierAPI := api.NewSupplierAPI(supplierService)
	supplierGroup := router.Group("/suppliers")
	{
		supplierGroup.GET("/", supplierAPI.GetAll)
		supplierGroup.GET("/:id", supplierAPI.GetByID)
		supplierGroup.POST("/", supplierAPI.Create)
		supplierGroup.PUT("/:id", supplierAPI.Update)
		supplierGroup.DELETE("/:id", supplierAPI.Delete)
	}

	territoryRepo := repositories.NewTerritoryRepository(db)
	territoryService := services.NewTerritoryService(territoryRepo)
	territoryAPI := api.NewTerritoryAPI(territoryService)
	territoryGroup := router.Group("/territories")
	{
		territoryGroup.GET("/", territoryAPI.GetAll)
		territoryGroup.GET("/:id", territoryAPI.GetByID)
		territoryGroup.POST("/", territoryAPI.Create)
		territoryGroup.PUT("/:id", territoryAPI.Update)
		territoryGroup.DELETE("/:id", territoryAPI.Delete)
	}

	router.Run(":" + port)

}
