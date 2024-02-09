
using Middleware.Domain;
using Middleware.Infra;

namespace Middleware.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }
        public bool Add(User user)
        {
            return _userRepository.Add(user);
        }

        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User Get(int id)
        {
            return _userRepository.Get(id);
        }

        public bool Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
