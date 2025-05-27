using Asp.Versioning;
using eShop.Application;
using eShop.Infrastructure;
using eShop.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;

namespace eShop.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(
            this WebApplicationBuilder builder)
        {

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);
            //builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.AddHealthChecks();


            builder.Services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.DefaultApiVersion = ApiVersion.Default;
            });

            // Configure HSTS options
            builder.Services.AddHsts(options =>
            {
                options.Preload = true;
                //options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(90); // Set to 60 days
            });

            builder.Services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                        options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

                    });

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });


            builder.Services.AddAuthentication();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "",
                    Description = "API",
                    TermsOfService = new Uri("https://www.gr"),
                    Contact = new OpenApiContact
                    {
                        Name = "Contact : IT Department",
                        Url = new Uri("https://www.gr")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "License : CC BY-NC-SA 4.0 DEED Attribution-NonCommercial-ShareAlike 4.0 International",
                        Url = new Uri("https://creativecommons.org/licenses/by-nc-sa/4.0/")
                    }
                });
                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
            builder.Services.AddHealthChecks();

          

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            //app.UseMiddleware<ClientIpAddressMiddleware>();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.ShowCommonExtensions();
                x.ShowExtensions();
                x.DisplayRequestDuration();
                x.EnableDeepLinking();
                x.InjectStylesheet("/swagger-ui/custom.css");
            });

            if (!app.Environment.IsDevelopment())
            {

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseSerilogRequestLogging();
            app.MapControllers();
            return app;
        }

        public static async Task MigrateDBAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<eShopDbContext>();
                if (context != null)
                {
                    //await context.Database.EnsureCreatedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                //add logging here later on
            }
        }
        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<eShopDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                //add logging here later on
            }
        }
    }
}
