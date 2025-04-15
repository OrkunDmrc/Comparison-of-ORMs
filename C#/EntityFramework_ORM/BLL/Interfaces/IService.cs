using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService<T, Tkey>
    {
        Task<List<T>> GetAllAsync();

        Task<T?> GetByIdAsync(Tkey id);
        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T?> DeleteAsync(Tkey id);
    }
}
