using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //#region Email
            //services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            //services.AddHttpClient("AzEmailAPI", httpClient =>
            //{
            //    httpClient.BaseAddress = new Uri(configuration?.GetSection("EmailSettings")?.GetValue<string>("BaseUri"));
            //    httpClient.DefaultRequestHeaders.Add("ApiKey", configuration.GetSection("EmailSettings").GetValue<string>("ApiKey"));
            //});
            //services.AddTransient<IEmailService, EmailService>();
            //#endregion

            //return services;
            
            return null;

        }

    }
}
