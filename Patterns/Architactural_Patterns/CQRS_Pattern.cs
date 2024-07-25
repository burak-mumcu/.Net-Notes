using Patterns.Architactural_Patterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Architactural_Patterns
{
    public class CreateUserCommand
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class CreateUserCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Handle(CreateUserCommand command)
        {
            var user = new User { UserName = command.UserName, Email = command.Email };
            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();
        }
    }
    public class GetUserByIdQuery
{
    public int UserId { get; set; }
}

public class GetUserByIdQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public User Handle(GetUserByIdQuery query)
    {
        return _unitOfWork.Users.GetById(query.UserId);
    }
}
    internal class CQRS_Pattern
    {
    }
}
