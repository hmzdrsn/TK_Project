using TK_Project.Application.Interfaces.Auth;
using TK_Project.Application.Interfaces.Repositories.User;
using TK_Project.Application.ViewModel;

namespace TK_Project.Persistance.Auth
{
    public class AuthService : IAuthService
    {
        readonly ITokenService _tokenService;
        readonly IUserReadRepository _readUser;

        public AuthService(ITokenService tokenService, IUserReadRepository readCustomer)
        {
            _tokenService = tokenService;
            _readUser = readCustomer;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _readUser.GetUserByName(loginRequest.Username);
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentNullException(nameof(user.Username));
            }

            var roleName = user.Roles.Select(x => x.Name).ToList();
            var capabilities = user.Roles.Select(c => c.Capabilities.Select(n => n.Name).ToList()).ToList();
            LoginResponse response = new();

            if (user.Username == loginRequest.Username && user.Password == loginRequest.Password)
            {
                var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequest { Username = user.Username, RoleName = roleName });

                response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
                response.AuthenticateResult = true;
                response.AuthToken = generatedTokenInformation.Token;
            }

            return response;
        }
    }
}
