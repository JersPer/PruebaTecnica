
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.Persistence;

namespace WebServices;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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
