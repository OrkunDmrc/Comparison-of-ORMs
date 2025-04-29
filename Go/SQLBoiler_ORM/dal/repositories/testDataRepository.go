package repositories

import (
	"SQLBOILER_ORM/dal/entities"
	"context"
	"database/sql"
	"errors"
)

type TestDataRepository struct {
	db *sql.DB
}

func NewTestDataRepository(db *sql.DB) *TestDataRepository {
	return &TestDataRepository{db: db}
}

func (r *TestDataRepository) Create(ctx context.Context, testData *entities.TestData) (*entities.TestData, error) {
	query := `INSERT INTO TestData (TestName, CpuUsage, MemoryUsage, Performance, Language) VALUES (@p1, @p2, @p3, @p4, @p5)`
	result, execErr := r.db.ExecContext(ctx, query, testData.TestName, testData.CpuUsage, testData.MemoryUsage, testData.Performance, testData.Language)
	if execErr != nil {
		return nil, execErr
	}
	lastInsertID, _ := result.LastInsertId()
	testData.ID = int(lastInsertID)
	return testData, nil
}

func (r *TestDataRepository) GetByID(ctx context.Context, id int) (*entities.TestData, error) {
	query := `SELECT * FROM TestData WHERE Id = @p1`
	row := r.db.QueryRowContext(ctx, query, id)
	var testData entities.TestData
	err := row.Scan(&testData.ID, &testData.TestName, &testData.CpuUsage, &testData.MemoryUsage, &testData.Performance, &testData.Language)
	if err != nil {
		if errors.Is(err, sql.ErrNoRows) {
			return nil, nil
		}
		return nil, err
	}
	return &testData, nil
}

func (r *TestDataRepository) Update(ctx context.Context, testData *entities.TestData) error {
	query := `UPDATE TestData SET TestName = @p1, CpuUsage = @p2, MemoryUsage = @p3, Performance = @p4, Language = @p5 WHERE Id = @p6`
	_, err := r.db.ExecContext(ctx, query, testData.TestName, testData.CpuUsage, testData.MemoryUsage, testData.Performance, testData.Language, testData.ID)
	return err
}

func (r *TestDataRepository) Delete(ctx context.Context, id int) error {
	query := `DELETE FROM TestData WHERE Id = @p1`
	_, err := r.db.ExecContext(ctx, query, id)
	return err
}

func (r *TestDataRepository) GetAll(ctx context.Context) ([]*entities.TestData, error) {
	query := `SELECT Id, TestName, CpuUsage, MemoryUsage, Performance, Language FROM TestData`
	rows, err := r.db.QueryContext(ctx, query)
	if err != nil {
		return nil, err
	}
	defer rows.Close()

	var testDataList []*entities.TestData
	for rows.Next() {
		var testData entities.TestData
		if err := rows.Scan(&testData.ID, &testData.TestName, &testData.CpuUsage, &testData.MemoryUsage, &testData.Performance, &testData.Language); err != nil {
			return nil, err
		}
		testDataList = append(testDataList, &testData)
	}
	return testDataList, nil
}
