using Web_Api.Models;

namespace Web_Api.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
    }

    public class UserService : IUserService
    {
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "User1" },
            new User { Id = 2, Name = "User2" }
        };

        public IEnumerable<User> GetUsers() => _users;
        public User GetUserById(int id) => _users.FirstOrDefault(u => u.Id == id);

    }

}
