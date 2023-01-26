using PruebaMedismart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace PruebaMedismart.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(
        ILogger<ApplicationDbContextInitialiser> logger, 
        ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task TrySeedAsync()
    {
        // Default data
        // Seed, if necessary
        if (!_context.Users.Any())
        {
            _context.Users.Add(new User()
            {
                Address = "Dirección de prueba",
                BirthDate = DateTime.Now,
                FirstName = "Usuario de prueba 1",
                LastName = "Usuario de prueba 1"
            });

            _context.Users.Add(new User()
            {
                Address = "Dirección de prueba",
                BirthDate = DateTime.Now,
                FirstName = "Usuario de prueba 2",
                LastName = "Usuario de prueba 2"
            });

            _context.Users.Add(new User()
            {
                Address = "Dirección de prueba",
                BirthDate = DateTime.Now,
                FirstName = "Usuario de prueba 3",
                LastName = "Usuario de prueba 3"
            });

            await _context.SaveChangesAsync();
        }
    }
}
