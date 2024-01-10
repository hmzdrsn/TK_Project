using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories;
using TK_Project.Application.Interfaces.Repositories.Capability;
using TK_Project.Application.Interfaces.Repositories.Category;
using TK_Project.Application.Interfaces.Repositories.User;
using TK_Project.Application.Interfaces.Repositories.Order;
using TK_Project.Application.Interfaces.Repositories.Product;
using TK_Project.Application.Interfaces.Repositories.Role;
using TK_Project.Persistance.Repositories;
using TK_Project.Persistance.Repositories.Capability;
using TK_Project.Persistance.Repositories.Category;
using TK_Project.Persistance.Repositories.Order;
using TK_Project.Persistance.Repositories.Product;
using TK_Project.Persistance.Repositories.Role;
using TK_Project.Persistance.Repositories.Customer;
using TK_Project.Application.Interfaces.Services;
using TK_Project.Persistance.Context;

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
            services.AddTransient<ICapabilityReadRepository, CapabilityReadRepository>();
            services.AddTransient<ICapabilityWriteRepository, CapabilityWriteRepository>();
            services.AddTransient<IRoleReadRepository, RoleReadRepository>();
            services.AddTransient<IRoleWriteRepository, RoleWriteRepository>();

        }
    }
}
