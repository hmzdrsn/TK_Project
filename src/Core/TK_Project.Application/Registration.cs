using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TK_Project.Application.Validators;
using TK_Project.Application.Validators.AuthValidators;
using TK_Project.Application.Validators.CategoryValidators;
using TK_Project.Application.Validators.MailValidators;
using TK_Project.Application.Validators.OrderValidators;
using TK_Project.Application.Validators.ProductValidators;
using TK_Project.Application.Validators.UserValidators;

namespace TK_Project.Application
{
    static public class Registration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            //Validator Registration
            services.AddValidatorsFromAssemblyContaining<ChangePasswordValidator>();
            services.AddValidatorsFromAssemblyContaining<RegisterValidator>();
            services.AddValidatorsFromAssemblyContaining<ProductValidator>();
            services.AddValidatorsFromAssemblyContaining<MailValidator>();
            //services.AddScoped<IValidator<ChangePasswordVM>, ChangePasswordValidator>();

            //cqrs validators
            services.AddValidatorsFromAssemblyContaining<AddUserCommandRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<AddCategoryCommandRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<AddOrderCommandRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<AddProductCommandRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<AddRoleCommandRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

            
        }

        
    }
}
