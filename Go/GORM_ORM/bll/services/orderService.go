package services

import (
	"GORM_ORM/dal/entities"
	"GORM_ORM/dal/repositories"
	"runtime"
	"strconv"
	"time"

	"golang.org/x/sys/windows"
)

type OrderService interface {
	GetAll() ([]entities.Order, error)
	GetByID(id int) (*entities.Order, error)
	Create(order *entities.Order) (*entities.Order, error)
	Update(order *entities.Order) error
	Delete(id int) error
}

type orderService struct {
	repo         repositories.OrderRepository
	testDataRepo repositories.TestDataRepository
}

func NewOrderService(repo repositories.OrderRepository, testDataRepo repositories.TestDataRepository) OrderService {
	return &orderService{repo: repo, testDataRepo: testDataRepo}
}

func (s *orderService) GetAll() ([]entities.Order, error) {
	var memStatsBefore, memStatsAfter runtime.MemStats
	cpuBefore := getCPUTime()
	runtime.ReadMemStats(&memStatsBefore)
	start := time.Now()

	orders, err := s.repo.GetAll()
	if err != nil {
		return nil, err
	}

	duration := time.Since(start)
	cpuAfter := getCPUTime()
	runtime.ReadMemStats(&memStatsAfter)
	memoryUsageMB := float64(memStatsAfter.Alloc-memStatsBefore.Alloc) / 1024 / 1024
	cpuUsageMs := (cpuAfter - cpuBefore).Milliseconds()

	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("GORM Get All Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr(formatMemory(memoryUsageMB)),
		CpuUsage:    stringPtr(strconv.FormatInt(cpuUsageMs, 10) + " ms"),
	}

	err = s.testDataRepo.Create(testData)
	if err != nil {
		return nil, err
	}

	return orders, nil
}

func (s *orderService) GetByID(id int) (*entities.Order, error) {
	var memStatsBefore, memStatsAfter runtime.MemStats
	cpuBefore := getCPUTime()
	runtime.ReadMemStats(&memStatsBefore)
	start := time.Now()

	entity, err := s.repo.GetByID(id)
	if err != nil {
		return nil, err
	}

	duration := time.Since(start)
	cpuAfter := getCPUTime()
	runtime.ReadMemStats(&memStatsAfter)
	memoryUsageMB := float64(memStatsAfter.Alloc-memStatsBefore.Alloc) / 1024 / 1024
	cpuUsageMs := (cpuAfter - cpuBefore).Milliseconds()

	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("GORM Get Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr(formatMemory(memoryUsageMB)),
		CpuUsage:    stringPtr(strconv.FormatInt(cpuUsageMs, 10) + " ms"),
	}

	err = s.testDataRepo.Create(testData)
	if err != nil {
		return nil, err
	}

	return entity, nil
}

func (s *orderService) Create(order *entities.Order) (*entities.Order, error) {
	var memStatsBefore, memStatsAfter runtime.MemStats
	cpuBefore := getCPUTime()
	runtime.ReadMemStats(&memStatsBefore)
	start := time.Now()

	entity, err := s.repo.Create(order)
	if err != nil {
		return nil, err
	}

	duration := time.Since(start)
	cpuAfter := getCPUTime()
	runtime.ReadMemStats(&memStatsAfter)
	memoryUsageMB := float64(memStatsAfter.Alloc-memStatsBefore.Alloc) / 1024 / 1024
	cpuUsageMs := (cpuAfter - cpuBefore).Milliseconds()

	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("GORM Create Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr(formatMemory(memoryUsageMB)),
		CpuUsage:    stringPtr(strconv.FormatInt(cpuUsageMs, 10) + " ms"),
	}

	err = s.testDataRepo.Create(testData)
	if err != nil {
		return nil, err
	}
	return entity, err
}

func (s *orderService) Update(order *entities.Order) error {
	var memStatsBefore, memStatsAfter runtime.MemStats
	cpuBefore := getCPUTime()
	runtime.ReadMemStats(&memStatsBefore)
	start := time.Now()

	err := s.repo.Update(order)
	if err != nil {
		return err
	}

	duration := time.Since(start)
	cpuAfter := getCPUTime()
	runtime.ReadMemStats(&memStatsAfter)
	memoryUsageMB := float64(memStatsAfter.Alloc-memStatsBefore.Alloc) / 1024 / 1024
	cpuUsageMs := (cpuAfter - cpuBefore).Milliseconds()

	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("GORM Update Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr(formatMemory(memoryUsageMB)),
		CpuUsage:    stringPtr(strconv.FormatInt(cpuUsageMs, 10) + " ms"),
	}

	err = s.testDataRepo.Create(testData)

	return err
}

func (s *orderService) Delete(id int) error {
	var memStatsBefore, memStatsAfter runtime.MemStats
	cpuBefore := getCPUTime()
	runtime.ReadMemStats(&memStatsBefore)
	start := time.Now()

	err := s.repo.Delete(id)
	if err != nil {
		return err
	}

	duration := time.Since(start)
	cpuAfter := getCPUTime()
	runtime.ReadMemStats(&memStatsAfter)
	memoryUsageMB := float64(memStatsAfter.Alloc-memStatsBefore.Alloc) / 1024 / 1024
	cpuUsageMs := (cpuAfter - cpuBefore).Milliseconds()

	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("GORM Delete Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr(formatMemory(memoryUsageMB)),
		CpuUsage:    stringPtr(strconv.FormatInt(cpuUsageMs, 10) + " ms"),
	}

	err = s.testDataRepo.Create(testData)

	return err
}

func stringPtr(s string) *string {
	return &s
}

func formatMemory(mb float64) string {
	return formatFloat(mb) + " MB"
}

func formatFloat(f float64) string {
	return strconv.FormatFloat(f, 'f', 2, 64)
}

func getCPUTime() time.Duration {
	var creationTime, exitTime, kernelTime, userTime windows.Filetime
	currentProcess := windows.CurrentProcess()
	err := windows.GetProcessTimes(currentProcess, &creationTime, &exitTime, &kernelTime, &userTime)
	if err != nil {
		return 0
	}
	return filetimeToDuration(userTime) + filetimeToDuration(kernelTime)
}

func filetimeToDuration(ft windows.Filetime) time.Duration {
	return time.Duration(ft.HighDateTime)<<32 + time.Duration(ft.LowDateTime)
}
