using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using DAL.Data;


namespace DAL.Repositories
{
    public class GenericRepository<T, Tkey> where T : class, IEntity
    {
        private MyAppDbContext _context;
        public GenericRepository(MyAppDbContext context) 
        {
            _context = context;
        }
        public async Task<List<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync(Tkey id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        
        public async Task<T?> DeleteAsync(Tkey id) 
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}
