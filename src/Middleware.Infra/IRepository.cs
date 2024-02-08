using Middleware.Domain;

namespace Middleware.Infra
{
    public interface IRepository<T>
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(Guid id);
        T Get(Guid id);
        IEnumerable<T> GetAll();
    }
}
