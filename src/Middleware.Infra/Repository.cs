
using Middleware.Domain;

namespace Middleware.Infra
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private static List<T> _entities = new();
        private static int _nextId = 1;
        public bool Add(T entityToAdd)
        {
            if (!_entities.Exists(existingEntity => existingEntity.Equals(entityToAdd)))
            {
                entityToAdd.Id = _nextId;
                _nextId++;
                _entities.Add(entityToAdd);
                return true;
            }
            return false;
        }

        public T Get(int id)
        {
            return _entities.FirstOrDefault(t => t.Id == id);
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            if (_entities.FirstOrDefault(existingEntity => existingEntity.Id == id) is T entityToRemove)
            {
                _entities.Remove(entityToRemove);
                return true;
            }
            return false;
        }

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }
    }
}
