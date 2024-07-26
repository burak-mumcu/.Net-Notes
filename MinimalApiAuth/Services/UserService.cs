using MinimalApiAuth.Models;

namespace MinimalApiAuth.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User Register(User user);
        IEnumerable<User> GetAll();
    }

    public class UserService : IUserService
    {
        private readonly List<User> _users = new List<User>();

        public User Authenticate(string username, string password)
        {
            return _users.SingleOrDefault(x => x.Username == username && x.Password == password);
        }

        public User Register(User user)
        {
            user.Id = _users.Count > 0 ? _users.Max(x => x.Id) + 1 : 1;
            _users.Add(user);
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }
    }
}
