package repositories

import (
	"GORM_ORM/dal/entities"

	"gorm.io/gorm"
)

type TestDataRepository interface {
	GetAll() ([]entities.TestData, error)
	GetByID(id int) (*entities.TestData, error)
	Create(entity *entities.TestData) error
	Update(entity *entities.TestData) error
	Delete(id int) error
}

type testDataRepository struct {
	genericRepo GenericRepository[entities.TestData]
}

func NewTestDataRepository(db *gorm.DB) TestDataRepository {
	return &testDataRepository{
		genericRepo: NewGenericRepository[entities.TestData](db),
	}
}

func (r *testDataRepository) GetAll() ([]entities.TestData, error) {
	return r.genericRepo.GetAll()
}

func (r *testDataRepository) GetByID(id int) (*entities.TestData, error) {
	return r.genericRepo.GetByID(id)
}

func (r *testDataRepository) Create(entity *entities.TestData) error {
	return r.genericRepo.Create(entity)
}

func (r *testDataRepository) Update(entity *entities.TestData) error {
	return r.genericRepo.Update(entity)
}

func (r *testDataRepository) Delete(id int) error {
	return r.genericRepo.Delete(id)
}
