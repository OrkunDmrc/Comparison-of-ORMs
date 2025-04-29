package services

import (
	"SQLBOILER_ORM/dal/entities"
	"SQLBOILER_ORM/dal/repositories"
	"context"
)

type TestDataService struct {
	repo *repositories.TestDataRepository
}

func NewTestDataService(repo *repositories.TestDataRepository) *TestDataService {
	return &TestDataService{repo: repo}
}

func (s *TestDataService) GetByID(ctx context.Context, id int) (*entities.TestData, error) {
	testData, err := s.repo.GetByID(ctx, id)
	if err != nil {
		return nil, err
	}
	return testData, nil
}

func (s *TestDataService) GetAll(ctx context.Context) ([]*entities.TestData, error) {
	return s.repo.GetAll(ctx)
}

func (s *TestDataService) Create(ctx context.Context, testData *entities.TestData) (*entities.TestData, error) {
	return s.repo.Create(ctx, testData)
}

func (s *TestDataService) Update(ctx context.Context, testData *entities.TestData) error {
	return s.repo.Update(ctx, testData)
}

func (s *TestDataService) Delete(ctx context.Context, id int) error {
	return s.repo.Delete(ctx, id)
}
