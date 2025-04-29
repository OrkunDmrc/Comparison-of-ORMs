package services

import (
	"SQLBOILER_ORM/dal/entities"
	"SQLBOILER_ORM/dal/repositories"
	"context"
	"runtime"
	"strconv"
	"time"
)

type OrderService struct {
	repo         *repositories.OrderRepository
	testDataRepo *repositories.TestDataRepository
}

func NewOrderService(repo *repositories.OrderRepository, testDataRepo *repositories.TestDataRepository) *OrderService {
	return &OrderService{repo: repo, testDataRepo: testDataRepo}
}

func (s *OrderService) GetByID(ctx context.Context, id int) (*entities.Order, error) {
	var memStatsBefore, memStatsAfter runtime.MemStats

	start := time.Now()
	order, err := s.repo.GetByID(ctx, id)
	duration := time.Since(start)
	if err != nil {
		return nil, err
	}

	runtime.ReadMemStats(&memStatsBefore)
	order2, err := s.repo.GetByID(ctx, id)
	runtime.ReadMemStats(&memStatsAfter)
	memoryUsageMB := float64(memStatsAfter.Alloc-memStatsBefore.Alloc) / 1024 / 1024
	if err != nil {
		return nil, err
	}

	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("SQLBoiler Get Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr(formatMemory(memoryUsageMB)),
		CpuUsage:    stringPtr("0 ms"),
	}

	_, err = s.testDataRepo.Create(ctx, testData)
	if err != nil {
		return nil, err
	}
	_ = order2
	return order, nil
}

func (s *OrderService) GetAll(ctx context.Context) ([]*entities.Order, error) {
	var memStatsBefore, memStatsAfter runtime.MemStats

	start := time.Now()
	orders, err := s.repo.GetAll(ctx)
	duration := time.Since(start)
	if err != nil {
		return nil, err
	}

	runtime.ReadMemStats(&memStatsBefore)
	orders2, err := s.repo.GetAll(ctx)
	runtime.ReadMemStats(&memStatsAfter)
	memoryUsageMB := float64(memStatsAfter.Alloc-memStatsBefore.Alloc) / 1024 / 1024
	if err != nil {
		return nil, err
	}

	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("SQLBoiler Get All Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr(formatMemory(memoryUsageMB)),
		CpuUsage:    stringPtr("0 ms"),
	}

	_, err = s.testDataRepo.Create(ctx, testData)
	if err != nil {
		return nil, err
	}
	_ = orders2
	return orders, nil
}

func (s *OrderService) Create(ctx context.Context, order *entities.Order) (*entities.Order, error) {
	var memStatsBefore, memStatsAfter runtime.MemStats

	start := time.Now()
	entity, err := s.repo.Create(ctx, order)
	duration := time.Since(start)
	if err != nil {
		return nil, err
	}

	runtime.ReadMemStats(&memStatsBefore)
	entity2, err := s.repo.Create(ctx, order)
	runtime.ReadMemStats(&memStatsAfter)
	memoryUsageMB := float64(memStatsAfter.Alloc-memStatsBefore.Alloc) / 1024 / 1024
	if err != nil {
		return nil, err
	}

	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("SQLBoiler Create Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr(formatMemory(memoryUsageMB)),
		CpuUsage:    stringPtr("0 ms"),
	}

	_, err = s.testDataRepo.Create(ctx, testData)
	if err != nil {
		return nil, err
	}
	_ = entity2
	return entity, nil
}

func (s *OrderService) Update(ctx context.Context, order *entities.Order) error {
	var memStatsBefore, memStatsAfter runtime.MemStats

	start := time.Now()
	err := s.repo.Update(ctx, order)
	duration := time.Since(start)
	if err != nil {
		return err
	}

	runtime.ReadMemStats(&memStatsBefore)
	err = s.repo.Update(ctx, order)
	runtime.ReadMemStats(&memStatsAfter)
	memoryUsageMB := float64(memStatsAfter.Alloc-memStatsBefore.Alloc) / 1024 / 1024
	if err != nil {
		return err
	}

	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("SQLBoiler Update Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr(formatMemory(memoryUsageMB)),
		CpuUsage:    stringPtr("0 ms"),
	}

	_, err = s.testDataRepo.Create(ctx, testData)
	if err != nil {
		return err
	}

	return err
}

func (s *OrderService) Delete(ctx context.Context, id int) error {
	var memStatsBefore, memStatsAfter runtime.MemStats

	start := time.Now()
	err := s.repo.Delete(ctx, id)
	duration := time.Since(start)
	if err != nil {
		return err
	}

	runtime.ReadMemStats(&memStatsBefore)
	err = s.repo.Delete(ctx, id)
	runtime.ReadMemStats(&memStatsAfter)
	memoryUsageMB := float64(memStatsAfter.Alloc-memStatsBefore.Alloc) / 1024 / 1024
	if err != nil {
		return err
	}

	testData := &entities.TestData{
		Language:    stringPtr("Golang"),
		TestName:    stringPtr("SQLBoiler Delete Operation"),
		Performance: stringPtr(duration.String()),
		MemoryUsage: stringPtr(formatMemory(memoryUsageMB)),
		CpuUsage:    stringPtr("0 ms"),
	}

	_, err = s.testDataRepo.Create(ctx, testData)
	if err != nil {
		return err
	}

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
