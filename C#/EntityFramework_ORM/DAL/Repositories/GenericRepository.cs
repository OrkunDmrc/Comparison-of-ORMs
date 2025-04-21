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
        public List<T> GetAll() => _context.Set<T>().ToList();

        public T? GetById(Tkey id) => _context.Set<T>().Find(id);

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
        
        public T? Delete(Tkey id) 
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
            return entity;
        }
    }
}
