package services

import (
	"GORM_ORM/dal/entities"
	"GORM_ORM/dal/repositories"
)

type TestDataService interface {
	GetAll() ([]entities.TestData, error)
	GetByID(id int) (*entities.TestData, error)
	Create(testData *entities.TestData) error
	Update(testData *entities.TestData) error
	Delete(id int) error
}

type testDataService struct {
	repo repositories.TestDataRepository
}

func NewTestDataService(repo repositories.TestDataRepository) TestDataService {
	return &testDataService{repo: repo}
}

func (s *testDataService) GetAll() ([]entities.TestData, error) {
	return s.repo.GetAll()
}

func (s *testDataService) GetByID(id int) (*entities.TestData, error) {
	return s.repo.GetByID(id)
}

func (s *testDataService) Create(testData *entities.TestData) error {
	return s.repo.Create(testData)
}

func (s *testDataService) Update(testData *entities.TestData) error {
	return s.repo.Update(testData)
}

func (s *testDataService) Delete(id int) error {
	return s.repo.Delete(id)
}
