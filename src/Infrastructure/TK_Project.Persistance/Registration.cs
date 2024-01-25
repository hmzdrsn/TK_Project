using Microsoft.Extensions.DependencyInjection;
using TK_Project.Application.Interfaces.Auth;
using TK_Project.Application.Interfaces.Repositories.Category;
using TK_Project.Application.Interfaces.Repositories.Order;
using TK_Project.Application.Interfaces.Repositories.Product;
using TK_Project.Application.Interfaces.Repositories.Role;
using TK_Project.Application.Interfaces.Repositories.User;
using TK_Project.Application.Interfaces.Services;
using TK_Project.Persistance.Auth;
using TK_Project.Persistance.Context;
using TK_Project.Persistance.Repositories.Category;
using TK_Project.Persistance.Repositories.Customer;
using TK_Project.Persistance.Repositories.Order;
using TK_Project.Persistance.Repositories.Product;
using TK_Project.Persistance.Repositories.Role;

namespace TK_Project.Persistance
{
    static public class Registration
    {
        public static void PersistanceRegister(this IServiceCollection services)
        {
            services.AddTransient<ICategoryReadRepository, CategoryReadRepository>();
            services.AddTransient<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddTransient<IProductReadRepository, ProductReadRepository>();
            services.AddTransient<IProductWriteRepository, ProductWriteRepository>();
            services.AddTransient<IUserReadRepository, UserReadRepository>();
            services.AddTransient<IUserWriteRepository, UserWriteRepository>();
            services.AddTransient<IOrderReadRepository, OrderReadRepository>();
            services.AddTransient<IOrderWriteRepository, OrderWriteRepository>();
            services.AddTransient<IRoleReadRepository, RoleReadRepository>();
            services.AddTransient<IRoleWriteRepository, RoleWriteRepository>();


            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ITokenService, TokenService>();
        }
    }
}
