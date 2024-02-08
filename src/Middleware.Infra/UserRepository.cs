using Middleware.Domain;

namespace Middleware.Infra
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users = new();

        public bool Add(User userToAdd)
        {
            if (!_users.Exists(existingUser => existingUser == userToAdd))
            {
                _users.Add(userToAdd);
                return true;
            }
            return false;
        }

        public void GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid userId)
        {
            if (_users.FirstOrDefault(existingUser => existingUser.Id == userId) is User userToRemove)
            {
                _users.Remove(userToRemove);
                return true;
            }
            return false;
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }
    }
}
