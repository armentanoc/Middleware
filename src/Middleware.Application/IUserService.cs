using Middleware.Domain;

namespace Middleware.Application
{
    public interface IUserService
    {
        bool Add(User user);
        void GetUser(Guid id);
        void Update(User user);
        bool Delete(Guid id);
        IEnumerable<User> GetAll();
    }
}
