using auction_system.Models;
using auction_system.UnitOfWork;

namespace auction_system.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User GetUser(int id)
        {
            return _unitOfWork.Users.Get(id);
        }

        public void CreateUser(User user)
        {
            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();
        }
    }
}
