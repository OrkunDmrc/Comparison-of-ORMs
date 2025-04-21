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
        List<T> GetAll();

        T? GetById(Tkey id);
        T Add(T entity);

        T Update(T entity);

        T? Delete(Tkey id);
    }
}
