using Microsoft.Extensions.DependencyInjection;
using TK_Project.Application.Interfaces.Services;
using TK_Project.Infrastructure.Services;

namespace TK_Project.Infrastructure
{
    static public class Registration
    {
        public static void InfrastructureRegister(this IServiceCollection services)
        {
            services.AddTransient<IMailService, MailService>();
            
        }
    }
}
