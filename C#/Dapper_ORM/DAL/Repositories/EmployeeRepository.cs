using DAL.Repositories;
using DAL.Entities;
using System.Data.SqlClient;
using Dapper;
namespace DAL.Repositories;

public class EmployeeRepository /*: GenericRepository<Employee, int>*/
{
    private readonly string _connectionString;
    public EmployeeRepository(string connectionString) /*: base(connectionString, "Employees", "EmployeeID")*/
    {
        _connectionString = connectionString;
    }

    [Obsolete]
    public async Task<List<Employee>> GetAllAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"SELECT * FROM Employees";
            var result = await connection.QueryAsync<Employee>(query);
            return result.ToList();
        }
    }
    [Obsolete]
    public async Task<Employee?> GetByIdAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = $"SELECT * FROM Employees WHERE EmployeeID = @Id";
            return await connection.QueryFirstOrDefaultAsync<Employee>(query, new { Id = id });
        }
    }
    [Obsolete]
    public async Task<Employee> AddAsync(Employee entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"INSERT INTO Employees (LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath)" +
                $" VALUES (@LastName, @FirstName, @Title, @TitleOfCourtesy, @BirthDate, @HireDate, @Address, @City, @Region, @PostalCode, @Country, @HomePhone, @Extension, @Photo, @Notes, @ReportsTo, @PhotoPath); SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = await connection.QuerySingleAsync<int>(query, entity);
            var propertyInfo = typeof(Employee).GetProperty("EmployeeID");
            propertyInfo.SetValue(entity, id);
            return entity;
        }
    }
    [Obsolete]
    public async Task UpdateAsync(Employee entity)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"UPDATE Employees SET (LastName = @LastName, FirstName = @FirstName, Title = @Title, TitleOfCourtesy = @TitleOfCourtesy, BirthDate = @BirthDate, " +
                $"HireDate = @HireDate, Address = @Address, City = @City, Region = @Region, PostalCode = @PostalCode, Country = @Country, HomePhone = @HomePhone, Extension = @Extension, Photo = @Photo, " +
                $"Notes = @Notes, ReportsTo = @ReportsTo, PhotoPath = @PhotoPath WHERE EmployeeID =  @EmployeeID";
            await connection.ExecuteAsync(query, entity);
        }
    }
    [Obsolete]
    public async Task DeleteAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = $"DELETE FROM Employees WHERE EmployeeID = @Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
