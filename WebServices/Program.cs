
using Microsoft.OpenApi.Models;
using PruebaMedismart.Infrastructure;
using PruebaMedismart.Infrastructure.Persistence;
using WebServices.Filters;

namespace WebServices;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers(options => options.Filters.Add<ExceptionFilter>());
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Prueba tecnica API",
                    Version = "v1",
                    Description = "Prueba tecnica API"
                }));

        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        var app = builder.Build();

        //Seed Data
        using (var scope = app.Services.CreateScope())
        {
            var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
            initialiser.InitialiseAsync().Wait();
            initialiser.SeedAsync().Wait();
        }

        //Swagger 
        app.UseSwagger();
        app.UseSwaggerUI();

        //Middlewares
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        //Run App
        app.Run();
    }
}
