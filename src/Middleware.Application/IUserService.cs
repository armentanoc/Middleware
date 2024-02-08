using Middleware.Domain;

namespace Middleware.Application
{
    public interface IUserService
    {
        bool Add(User user);
        bool Update(User user);
        bool Delete(Guid id);
        User Get(Guid id);
        IEnumerable<User> GetAll();
    }
}
