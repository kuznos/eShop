using eShop.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder
       .ConfigureServices()
       .ConfigurePipeline();
await app.MigrateDBAsync();

app.Run();
