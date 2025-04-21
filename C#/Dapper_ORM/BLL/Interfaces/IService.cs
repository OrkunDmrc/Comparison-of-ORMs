

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
