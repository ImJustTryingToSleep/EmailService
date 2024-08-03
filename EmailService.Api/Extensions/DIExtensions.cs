using EmailService.BLL.Logic.Contracts.Email;
using EmailService.BLL.Logic.Email;

namespace EmailService.Api.Extensions
{
    public static class DIExtensions
    {
        public static IServiceCollection ConfigureBLLDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmailCreationLogic, EmailCreationLogic>();
            services.AddScoped<IEmailSenderLogic, EmailSenderLogic>();
            return services;
        }
    }
}
