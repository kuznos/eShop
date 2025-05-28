using eShop.Application.Contracts.Persistence;
using eShop.Application.Contracts.Persistence.eShop;
using eShop.Persistence.Repositories;
using eShop.Persistence.Repositories.eShop;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<eShopDbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("SQLConnectionStringLocal")));
            //services.AddDbContext<eShopDbContext>(options =>
            //      options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
