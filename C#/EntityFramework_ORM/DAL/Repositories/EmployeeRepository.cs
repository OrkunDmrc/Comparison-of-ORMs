using DAL.Repositories;
using DAL.Entities;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class EmployeeRepository /*: GenericRepository<Employee, int>*/
{
    private MyAppDbContext _context;
    public EmployeeRepository(MyAppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Employee>> GetAllAsync() => await _context.Set<Employee>().ToListAsync();

    public async Task<Employee?> GetByIdAsync(int id) => await _context.Set<Employee>().FindAsync(id);

    public async Task<Employee> AddAsync(Employee entity)
    {
        await _context.Set<Employee>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Employee entity)
    {
        _context.Set<Employee>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<Employee>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
