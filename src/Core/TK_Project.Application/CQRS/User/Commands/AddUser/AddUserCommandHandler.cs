using MediatR;
using TK_Project.Application.Interfaces.Repositories.User;

namespace TK_Project.Application.CQRS.User.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommandRequest, AddUserCommandResponse>
    {
        readonly IUserWriteRepository _write;

        public AddUserCommandHandler(IUserWriteRepository write)
        {
            _write = write;
        }

        public async Task<AddUserCommandResponse> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _write.AddAsync(new Domain.Entities.User()
            {
                Username = request.Username,
                Password = request.Password,
                First_Name = request.First_Name,
                Last_Name = request.Last_Name,
                Address = request.Address,
                Mail = request.Mail,
                Phone_Number = request.Phone_Number
            });

            return new AddUserCommandResponse()
            {
                Message = "User Created"
            };

        }
    }
}
