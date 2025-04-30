package repositories

import (
	"GORM_ORM/dal/entities"
	"time"

	"gorm.io/gorm"
)

type OrderRepository interface {
	GetAll() ([]entities.Order, error)
	GetByID(id int) (*entities.Order, error)
	Create(entity *entities.Order) (*entities.Order, error)
	Update(entity *entities.Order) error
	Delete(id int) error
	AllTables() error
}

type orderRepository struct {
	//genericRepo GenericRepository[entities.Order]
	db           *gorm.DB
	testDataRepo TestDataRepository
}

func NewOrderRepository(db *gorm.DB, testDataRepo TestDataRepository) OrderRepository {
	return &orderRepository{
		//genericRepo: NewGenericRepository[entities.Order](db),
		db:           db,
		testDataRepo: testDataRepo,
	}
}

func (r *orderRepository) GetAll() ([]entities.Order, error) {
	var orders []entities.Order
	start := time.Now()
	err := r.db.Find(&orders).Error
	duration := time.Since(start)
	if err != nil {
		return nil, err
	}
	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("GORM Get All Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr( /*formatMemory(memoryUsageMB)*/ "0 MB"),
		CpuUsage:    stringPtr( /*strconv.FormatInt(cpuUsageMs, 10)*/ "0 ms"),
	}
	err = r.testDataRepo.Create(testData)
	if err != nil {
		return nil, err
	}
	return orders, err
}

func (r *orderRepository) GetByID(id int) (*entities.Order, error) {
	var entity entities.Order
	start := time.Now()
	err := r.db.First(&entity, id).Error
	duration := time.Since(start)
	if err != nil {
		return nil, err
	}
	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("GORM Get Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr( /*formatMemory(memoryUsageMB)*/ "0 MB"),
		CpuUsage:    stringPtr( /*strconv.FormatInt(cpuUsageMs, 10)*/ "0 ms"),
	}
	err = r.testDataRepo.Create(testData)
	if err != nil {
		return nil, err
	}
	return &entity, nil
}

func (r *orderRepository) Create(entity *entities.Order) (*entities.Order, error) {
	start := time.Now()
	err := r.db.Create(entity).Error
	duration := time.Since(start)
	if err != nil {
		return nil, err
	}
	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("GORM Create Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr( /*formatMemory(memoryUsageMB)*/ "0 MB"),
		CpuUsage:    stringPtr( /*strconv.FormatInt(cpuUsageMs, 10)*/ "0 ms"),
	}
	err = r.testDataRepo.Create(testData)
	if err != nil {
		return nil, err
	}
	return entity, nil
}

func (r *orderRepository) Update(entity *entities.Order) error {
	start := time.Now()
	err := r.db.Save(entity).Error
	duration := time.Since(start)
	if err != nil {
		return err
	}
	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("GORM Update Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr( /*formatMemory(memoryUsageMB)*/ "0 MB"),
		CpuUsage:    stringPtr( /*strconv.FormatInt(cpuUsageMs, 10)*/ "0 ms"),
	}
	err = r.testDataRepo.Create(testData)
	if err != nil {
		return err
	}
	return nil
}

func (r *orderRepository) Delete(id int) error {
	var entity entities.Order
	start := time.Now()
	err := r.db.Delete(&entity, id).Error
	duration := time.Since(start)
	if err != nil {
		return err
	}
	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("GORM Delete Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr( /*formatMemory(memoryUsageMB)*/ "0 MB"),
		CpuUsage:    stringPtr( /*strconv.FormatInt(cpuUsageMs, 10)*/ "0 ms"),
	}
	err = r.testDataRepo.Create(testData)
	if err != nil {
		return err
	}
	return nil
}

func (r *orderRepository) AllTables() error {
	start := time.Now()
	rows, err := r.db.Raw(`
		SELECT o.*, e.*, c.*, s.*, od.*, p.*, ct.*, sp.*, et.*, t.*, r.*
		FROM Orders o
		JOIN Employees e ON e.EmployeeID = o.EmployeeID
		JOIN Customers c ON c.CustomerID = o.CustomerID
		JOIN Shippers s ON s.ShipperID = o.ShipVia
		JOIN [Order Details] od ON od.OrderID = o.OrderID
		JOIN Products p ON p.ProductID = od.ProductID
		JOIN Categories ct ON ct.CategoryID = p.CategoryID
		JOIN Suppliers sp ON sp.SupplierID = p.SupplierID
		JOIN EmployeeTerritories et ON et.EmployeeID = e.EmployeeID
		JOIN Territories t ON t.TerritoryID = et.TerritoryID
		JOIN Region r ON r.RegionID = t.RegionID
	`).Rows()
	duration := time.Since(start)
	_ = rows
	if err != nil {
		return err
	}
	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("GORM All Tables Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr( /*formatMemory(memoryUsageMB)*/ "0 MB"),
		CpuUsage:    stringPtr( /*strconv.FormatInt(cpuUsageMs, 10)*/ "0 ms"),
	}
	err = r.testDataRepo.Create(testData)
	if err != nil {
		return err
	}
	return nil
}

func stringPtr(s string) *string {
	return &s
}
