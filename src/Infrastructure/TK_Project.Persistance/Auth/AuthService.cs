using FluentValidation;
using TK_Project.Application.Interfaces.Auth;
using TK_Project.Application.Interfaces.Repositories.Role;
using TK_Project.Application.Interfaces.Repositories.User;
using TK_Project.Application.ViewModel;
using TK_Project.Domain.Entities;
using TK_Project.Persistance.Repositories.Customer;

namespace TK_Project.Persistance.Auth
{
    public class AuthService : IAuthService
    {
        readonly ITokenService _tokenService;
        readonly IUserReadRepository _readUser;
        readonly IUserWriteRepository _writeUser;
        readonly IRoleWriteRepository _writeRole;
        public AuthService(ITokenService tokenService, IUserReadRepository readCustomer, IUserWriteRepository writeUser, IRoleWriteRepository writeRole)
        {
            _tokenService = tokenService;
            _readUser = readCustomer;
            _writeUser = writeUser;
            _writeRole = writeRole;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _readUser.GetUserByUsername(loginRequest.Username);
            if(user == null)
            {
                return new()
                {
                    State= "username or password is incorrect!"
                };
                
            }
            else if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                return new()
                {
                    State = "username or password is incorrect!"
                };
            }
            else
            {
                var roleName = user.Roles.Select(x => x.Name).ToList();
                LoginResponse response = new();

                if (user.Username == loginRequest.Username && user.Password == loginRequest.Password)
                {
                    var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequest { Username = user.Username, RoleName = roleName });

                    response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
                    response.AuthenticateResult = true;
                    response.AuthToken = generatedTokenInformation.Token;
                    response.State = "logged in successfully";
                }
                return response;
            }
        }

        public async Task RegisterAsync(RegisterVM registerVM)
        {
            if(registerVM != null)
            {
                List<int> roles = new List<int>();
                roles.Add(2);
                await _writeUser.AddAsync(new Domain.Entities.User()
                {
                    Username = registerVM.Username,
                    Password = registerVM.Password,
                    First_Name = registerVM.First_Name,
                    Last_Name = registerVM.Last_Name,
                    Mail = registerVM.Mail,
                    Phone_Number = registerVM.Phone_Number,
                });
                var userData = await _readUser.GetUserByUsername(registerVM.Username);
                await _writeRole.AssignRole(userData.Id,roles);
            }
        }

    }
}
