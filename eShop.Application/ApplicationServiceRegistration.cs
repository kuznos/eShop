
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            //FluentValidation
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            //FluentValidation one by one
            //services.AddValidatorsFromAssemblyContaining<CreateNotificationCommandValidator>();
            return services;
        }
    }
}
