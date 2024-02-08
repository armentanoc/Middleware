using Middleware.Domain;

namespace Middleware.Infra
{
    public interface IUserRepository
    {
        bool Add(User user);
        void GetUser(Guid id);
        void Update(User user);
        bool Delete(Guid id);
        IEnumerable<User> GetAll();
    }
}
