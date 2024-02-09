using Middleware.Domain;

namespace Middleware.Application
{
    public interface IUserService
    {
        bool Add(User user);
        bool Update(User user);
        bool Delete(int id);
        User Get(int id);
        IEnumerable<User> GetAll();
    }
}
