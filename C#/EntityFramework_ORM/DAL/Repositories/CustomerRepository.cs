using DAL.Entities;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CustomerRepository /*: GenericRepository<Customer, string>*/
{
    private MyAppDbContext _context;
    public CustomerRepository(MyAppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Customer>> GetAllAsync() => await _context.Set<Customer>().ToListAsync();

    public async Task<Customer?> GetByIdAsync(string id) => await _context.Set<Customer>().FindAsync(id);

    public async Task<Customer> AddAsync(Customer entity)
    {
        await _context.Set<Customer>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Customer entity)
    {
        _context.Set<Customer>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<Customer>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
