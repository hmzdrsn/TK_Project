using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.ViewModel;

namespace TK_Project.Application.Interfaces.Auth
{
    public interface IAuthService
    {
        public Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    }
}
