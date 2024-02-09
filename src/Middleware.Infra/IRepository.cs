using Middleware.Domain;

namespace Middleware.Infra
{
    public interface IRepository<T>
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
